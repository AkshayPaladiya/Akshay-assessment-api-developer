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
                    Value = ((int)c).ToString()
                })
                .ToArray();

            countryDropDownList.Items.Clear();
            countryDropDownList.Items.AddRange(countryList);
            countryDropDownList.SelectedValue = ((int)Countries.Canada).ToString();  // Default to Canada

            // Populate state dropdown (Enums for Canadian Provinces)
            var provinceList = Enum.GetValues(typeof(CanadianProvinces))
                .Cast<CanadianProvinces>()
                .Select(p => new ListItem
                {
                    Text = p.ToString(),
                    Value = ((int)p).ToString()
                })
                .ToArray();

            stateDropDownList.Items.Clear();
            stateDropDownList.Items.Add(new ListItem("Select Province", ""));
            stateDropDownList.Items.AddRange(provinceList);
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
