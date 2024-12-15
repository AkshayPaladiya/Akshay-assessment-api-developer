using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleInjector;
using System.Linq;
using assessment_platform_developer.Models;
using assessment_platform_developer.Services;
using assessment_platform_developer.Helpers;

namespace assessment_platform_developer
{
    public partial class Customers : Page
    {
        private static List<Customer> customers = new List<Customer>();
        
        


        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the DI container from the Application context
                var testContainer = (Container)HttpContext.Current.Application["DIContainer"];

                if (testContainer == null)
                {
                    throw new InvalidOperationException("DI Container is not initialized.");
                }

                // Resolve the ICustomerApiService instance from the container
                var customerApiService = testContainer.GetInstance<ICustomerApiService>();

                

                // Fetch all customers on the initial page load
                var allCustomers = customerApiService.GetAllCustomersAsync().Result;
                ViewState["Customers"] = allCustomers;

                // Populate country and state dropdowns
                CustomerHelper.PopulateCustomerDropDownLists(CountryDropDownList, StateDropDownList);
            }
            else
            {
                // On postback, load customers from ViewState
                customers = (List<Customer>)ViewState["Customers"];
            }

        }

        // Populate the Customers dropdown list
        protected async void PopulateCustomerListBox()
        {
            CustomersDDL.Items.Clear();
            CustomersDDL.Items.Add(new ListItem
            {
                Text = "Select Customer",
                Value = ""
            });

            try
            {
                var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
                var customerApiService = testContainer.GetInstance<ICustomerApiService>();

                var customerList = await customerApiService.GetAllCustomersAsync();

                if (customerList != null && customerList.Count > 0)
                {
                    var customerItems = customerList.Select(c => new ListItem
                    {
                        Text = c.Name,
                        Value = c.ID.ToString()
                    }).ToArray();

                    CustomersDDL.Items.AddRange(customerItems);
                    
                }
                else
                {
                    CustomersDDL.Items.Add(new ListItem("No customers found"));
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Add a new customer to the system
        protected async void AddButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            // Use the helper method to populate the customer object with the form data
            CustomerHelper.PopulateCustomerFromForm(customer, CustomerName, CustomerAddress, CustomerCity, StateDropDownList,
                                                     CustomerZip, CountryDropDownList, CustomerEmail, CustomerPhone,
                                                     CustomerNotes, ContactName, ContactPhone, ContactEmail);

            try
            {
                var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
                var customerApiService = testContainer.GetInstance<ICustomerApiService>();
                var addedCustomer = await customerApiService.AddCustomerAsync(customer);
                customers.Add(addedCustomer);

                // Refresh the customer list in the dropdown
                PopulateCustomerListBox();

                // Clear the form after submission
                CustomerHelper.ClearCustomerForm(CustomerName, CustomerAddress, CustomerEmail, CustomerPhone, CustomerCity, StateDropDownList,
                                                  CustomerZip, CountryDropDownList, CustomerNotes, ContactName, ContactPhone, ContactEmail);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Handle customer selection change in the dropdown
        protected async void CustomersDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCustomerId = CustomersDDL.SelectedValue;

            if (!string.IsNullOrEmpty(selectedCustomerId))
            {
                try
                {
                    int customerId = int.Parse(selectedCustomerId);
                    var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
                    var customerApiService = testContainer.GetInstance<ICustomerApiService>();
                    var customer = await customerApiService.GetCustomerByIdAsync(customerId);

                    if (customer != null)
                    {
                        CustomerHelper.PopulateCustomerDropDownLists(CountryDropDownList, StateDropDownList);

                        // Use the helper method to populate the form fields with customer data
                        CustomerHelper.PopulateCustomerFormFromCustomer(customer, CustomerName, CustomerAddress, CustomerCity, StateDropDownList,
                                                                        CustomerZip, CountryDropDownList, CustomerEmail, CustomerPhone,
                                                                        CustomerNotes, ContactName, ContactPhone, ContactEmail);


                        UpdateButton.Visible = true;
                        DeleteButton.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Customer not found.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                UpdateButton.Visible = false;
                DeleteButton.Visible = false;
            }
        }

        // Update an existing customer's information
        protected async void UpdateButton_Click(object sender, EventArgs e)
        {
            string selectedCustomerId = CustomersDDL.SelectedValue;

            if (!string.IsNullOrEmpty(selectedCustomerId))
            {
                try
                {
                    int customerId = int.Parse(selectedCustomerId);
                    var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
                    var customerApiService = testContainer.GetInstance<ICustomerApiService>();
                    var customer = await customerApiService.GetCustomerByIdAsync(customerId);

                    if (customer != null)
                    {
                        // Use the helper method to populate the customer object with the form data
                        CustomerHelper.PopulateCustomerFromForm(customer, CustomerName, CustomerAddress, CustomerCity, StateDropDownList,
                                                                 CustomerZip, CountryDropDownList, CustomerEmail, CustomerPhone,
                                                                 CustomerNotes, ContactName, ContactPhone, ContactEmail);


                        var updatedCustomer = await customerApiService.UpdateCustomerAsync(customerId, customer);

                        if (updatedCustomer != null)
                        {
                            Response.Write("<script>alert('Customer updated successfully.');</script>");
                            PopulateCustomerListBox();
                            CustomerHelper.ClearCustomerForm(CustomerName, CustomerAddress, CustomerEmail, CustomerPhone, CustomerCity, StateDropDownList,
                                                              CustomerZip, CountryDropDownList, CustomerNotes, ContactName, ContactPhone, ContactEmail);
                            UpdateButton.Visible = false;
                            DeleteButton.Visible = false;
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to update customer.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Customer not found.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a customer to update.');</script>");
            }
        }

        // Delete a customer from the system
        protected async void DeleteButton_Click(object sender, EventArgs e)
        {
            string selectedCustomerId = CustomersDDL.SelectedValue;

            if (!string.IsNullOrEmpty(selectedCustomerId))
            {
                try
                {
                    int customerId = int.Parse(selectedCustomerId);

                    var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
                    var customerApiService = testContainer.GetInstance<ICustomerApiService>();
                    var customer = await customerApiService.GetCustomerByIdAsync(customerId);

                    if (customer != null)
                    {
                        var isDeleted = await customerApiService.DeleteCustomerAsync(customerId);

                        if (isDeleted)
                        {
                            Response.Write("<script>alert('Customer deleted successfully.');</script>");
                            customers.Remove(customer);
                            PopulateCustomerListBox();
                            CustomerHelper.ClearCustomerForm(CustomerName, CustomerAddress, CustomerEmail, CustomerPhone, CustomerCity, StateDropDownList,
                                                              CustomerZip, CountryDropDownList, CustomerNotes, ContactName, ContactPhone, ContactEmail);
                            UpdateButton.Visible = false;
                            DeleteButton.Visible = false;
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to delete customer.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Customer not found.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a customer to delete.');</script>");
            }
        }
    }
}
