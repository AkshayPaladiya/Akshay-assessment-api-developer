using System;
using System.Web.UI.WebControls;
using System.Linq;
using assessment_platform_developer.Models;

namespace assessment_platform_developer.Helpers
{
    public static class CustomerHelper
    {
        // Method to populate country and state dropdowns
        public static void PopulateCustomerDropDownLists(DropDownList countryDropDownList, DropDownList stateDropDownList)
        {
            // Populate country dropdown (Enums for Countries)
            var countryList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new ListItem
                {
                    Text = c.ToString(),
                    Value = c.ToString()
                })
                .ToArray();

            countryDropDownList.Items.Clear();
            countryDropDownList.Items.AddRange(countryList);
            countryDropDownList.SelectedValue = (Countries.Canada).ToString();  // Default to Canada

            // Populate state dropdown (Enums for Canadian Provinces)
            var provinceList = Enum.GetValues(typeof(CanadianProvinces))
                .Cast<CanadianProvinces>()
                .Select(p => new ListItem
                {
                    Text = p.ToString(),
                    Value = p.ToString()
                })
                .ToArray();

            stateDropDownList.Items.Clear();
            stateDropDownList.Items.Add(new ListItem("Select Province", ""));
            stateDropDownList.Items.AddRange(provinceList);
        }

        // A helper method to populate the customer object with data from the form fields
        public static void PopulateCustomerFromForm(Customer customer, TextBox customerName, TextBox customerAddress, TextBox customerCity,
                                                     DropDownList stateDropDown, TextBox customerZip, DropDownList countryDropDown,
                                                     TextBox customerEmail, TextBox customerPhone, TextBox customerNotes,
                                                     TextBox contactName, TextBox contactPhone, TextBox contactEmail)
        {
            customer.Name = customerName.Text;
            customer.Address = customerAddress.Text;
            customer.City = customerCity.Text;
            customer.State = stateDropDown.SelectedValue;  // Use SelectedValue if the dropdown stores state values
            customer.Zip = customerZip.Text;
            customer.Country = countryDropDown.SelectedValue;  // Use SelectedValue for Country dropdown
            customer.Email = customerEmail.Text;
            customer.Phone = customerPhone.Text;
            customer.Notes = customerNotes.Text;
            customer.ContactName = contactName.Text;
            customer.ContactPhone = contactPhone.Text;
            customer.ContactEmail = contactEmail.Text;
        }

        // Method to populate the customer form with data
        public static void PopulateCustomerFormFromCustomer(Customer customer, TextBox customerName, TextBox customerAddress, TextBox customerCity,
                                                             DropDownList stateDropDown, TextBox customerZip, DropDownList countryDropDown,
                                                             TextBox customerEmail, TextBox customerPhone, TextBox customerNotes,
                                                             TextBox contactName, TextBox contactPhone, TextBox contactEmail)
        {
            customerName.Text = customer.Name;
            customerAddress.Text = customer.Address;
            customerCity.Text = customer.City;
            stateDropDown.SelectedValue = customer.State;
            customerZip.Text = customer.Zip;
            countryDropDown.SelectedValue = customer.Country;
            customerEmail.Text = customer.Email;
            customerPhone.Text = customer.Phone;
            customerNotes.Text = customer.Notes;
            contactName.Text = customer.ContactName;
            contactPhone.Text = customer.ContactPhone;
            contactEmail.Text = customer.ContactEmail;
        }


        // Method to clear customer form fields
        public static void ClearCustomerForm(TextBox customerName, TextBox customerAddress, TextBox customerEmail,
                                             TextBox customerPhone, TextBox customerCity, DropDownList stateDropDownList,
                                             TextBox customerZip, DropDownList countryDropDownList, TextBox customerNotes,
                                             TextBox contactName, TextBox contactPhone, TextBox contactEmail)
        {
            customerName.Text = string.Empty;
            customerAddress.Text = string.Empty;
            customerEmail.Text = string.Empty;
            customerPhone.Text = string.Empty;
            customerCity.Text = string.Empty;
            stateDropDownList.SelectedIndex = 0;
            customerZip.Text = string.Empty;
            countryDropDownList.SelectedIndex = 0;
            customerNotes.Text = string.Empty;
            contactName.Text = string.Empty;
            contactPhone.Text = string.Empty;
            contactEmail.Text = string.Empty;
        }
    }
}
