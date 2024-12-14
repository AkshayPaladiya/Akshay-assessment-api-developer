using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using assessment_platform_developer.Services;
using Container = SimpleInjector.Container;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace assessment_platform_developer
{
    public partial class Customers : Page
    {
        private static List<Customer> customers = new List<Customer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
                var customerService = testContainer.GetInstance<ICustomerService>();

                var allCustomers = customerService.GetAllCustomers();
                ViewState["Customers"] = allCustomers;
            }
            else
            {
                customers = (List<Customer>)ViewState["Customers"];
            }

            // Populate country and state dropdowns
            PopulateCustomerDropDownLists();
        }

        // Populate state and country dropdowns
        private void PopulateCustomerDropDownLists()
        {
            // Populate country dropdown (Enums for Countries)
            var countryList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new ListItem
                {
                    Text = c.ToString(),
                    Value = ((int)c).ToString()
                })
                .ToArray();

            CountryDropDownList.Items.AddRange(countryList);
            CountryDropDownList.SelectedValue = ((int)Countries.Canada).ToString();  // Default to Canada

            // Populate province (state) dropdown (Enums for Canadian Provinces)
            var provinceList = Enum.GetValues(typeof(CanadianProvinces))
                .Cast<CanadianProvinces>()
                .Select(p => new ListItem
                {
                    Text = p.ToString(),
                    Value = ((int)p).ToString()
                })
                .ToArray();

            StateDropDownList.Items.Add(new ListItem("Select Province", ""));
            StateDropDownList.Items.AddRange(provinceList);
        }

        // Populate the Customers dropdown list with customers from the API
        protected async void PopulateCustomerListBox()
        {
            CustomersDDL.Items.Clear();
            CustomersDDL.Items.Add(new ListItem
            {
                Text = "Select Coustomer",
                Value = ""
            });

            try
            {
                // Create an HttpClient instance
                using (var client = new HttpClient())
                {
                    // Set the base address of the API
                    client.BaseAddress = new Uri("https://localhost:44358/");

                    // Send GET request to retrieve all customers
                    var response = await client.GetAsync("api/customers");

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content of the response as a string
                        var responseContent = await response.Content.ReadAsStringAsync();

                        // Deserialize the string into a list of customers
                        var customers = JsonConvert.DeserializeObject<List<Customer>>(responseContent);

                        // Check if there are any customers and populate the dropdown list
                        if (customers != null && customers.Count > 0)
                        {
                            // var customerItems = customers.Select(c => new ListItem(c.Name)).ToArray();

                            var customerItems = customers.Select(c => new ListItem
                            {
                                Text = c.Name,           // Display Name of the customer
                                Value = c.ID.ToString()  // Use Customer ID as the Value
                            }).ToArray();

                            CustomersDDL.Items.AddRange(customerItems);
                            CustomersDDL.SelectedIndex = 0;
                        }
                        else
                        {
                            // If no customers, add a placeholder
                            CustomersDDL.Items.Add(new ListItem("No customers found"));
                        }
                    }
                    else
                    {
                        // If the API call fails, show an error message
                        Response.Write("<script>alert('Failed to retrieve customers.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and handle any exceptions (e.g., network issues)
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Handle the Add Customer button click event
        protected async void AddButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = CustomerName.Text,
                Address = CustomerAddress.Text,
                City = CustomerCity.Text,
                State = StateDropDownList.SelectedValue,
                Zip = CustomerZip.Text,
                Country = CountryDropDownList.SelectedValue,
                Email = CustomerEmail.Text,
                Phone = CustomerPhone.Text,
                Notes = CustomerNotes.Text,
                ContactName = ContactName.Text,
                ContactPhone = ContactPhone.Text,
                ContactEmail = ContactEmail.Text
            };

            try
            {
                // Create an HttpClient instance
                using (var client = new HttpClient())
                {
                    // Set the base address of the API
                    client.BaseAddress = new Uri("https://localhost:44358/");

                    // Set the content type for the request
                    var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                    // Make the POST request to the API to add a new customer
                    var response = await client.PostAsync("api/customers", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // If successful, retrieve the added customer (optional, or you can just refresh UI)
                        var addedCustomer = await response.Content.ReadAsAsync<Customer>();

                        // Add the customer to the in-memory list
                        customers.Add(addedCustomer);

                        // Refresh the customer list in the dropdown
                        PopulateCustomerListBox();

                        // Clear form fields after submission
                        ClearCustomerForm();
                    }
                    else
                    {
                        // Handle failure response (e.g., show an error message)
                        Response.Write("<script>alert('Failed to add customer.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and handle any exceptions (e.g., network issues)
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Clear customer form fields
        private void ClearCustomerForm()
        {
            CustomerName.Text = string.Empty;
            CustomerAddress.Text = string.Empty;
            CustomerEmail.Text = string.Empty;
            CustomerPhone.Text = string.Empty;
            CustomerCity.Text = string.Empty;
            StateDropDownList.SelectedIndex = 0;
            CustomerZip.Text = string.Empty;
            CountryDropDownList.SelectedIndex = 0;
            CustomerNotes.Text = string.Empty;
            ContactName.Text = string.Empty;
            ContactPhone.Text = string.Empty;
            ContactEmail.Text = string.Empty;
        }





    }
}
