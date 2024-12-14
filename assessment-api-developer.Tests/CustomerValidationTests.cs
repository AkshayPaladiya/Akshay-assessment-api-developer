using assessment_platform_developer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace assessment_platform_developer.Tests
{
    [TestClass]
    public class CustomerValidationTests
    {
        private bool ValidateCustomer(Customer customer, out List<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(customer);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(customer, validationContext, validationResults, true);
        }

        [TestMethod]
        public void Customer_ValidFields_ReturnsValid()
        {
            var customer = new Customer
            {
                ID = 1,
                Name = "John Doe",
                Address = "123 Main St",
                Email = "johndoe@example.com",
                Phone = "+1234567890",
                City = "New York",
                State = "New York",
                Zip = "10001",
                Country = "United States",
                Notes = "Test notes",
                ContactName = "Jane Doe",
                ContactPhone = "+1987654321",
                ContactEmail = "janedoe@example.com"
            };

            Assert.IsTrue(ValidateCustomer(customer, out var validationResults));
        }

        [TestMethod]
        [DataRow("", "Name is required.")]
        [DataRow("invalid-email", "Invalid email format.")]
        [DataRow("invalid-phone", "Invalid phone number format.")]
        [DataRow("InvalidZip", "Invalid zip/postal code format.")]
        [DataRow("Mexico", "Country must be either 'Canada' or 'United States'.")]
        public void Customer_InvalidFields_ReturnsInvalid(string invalidValue, string expectedErrorMessage)
        {
            var customer = new Customer
            {
                ID = 1,
                Name = "John Doe",
                Address = "123 Main St",
                Email = "johndoe@example.com",
                Phone = "+1234567890",
                City = "New York",
                State = "New York",
                Zip = "10001",
                Country = "United States",
                Notes = "Test notes",
                ContactName = "Jane Doe",
                ContactPhone = "+1987654321",
                ContactEmail = "janedoe@example.com"
            };

            // Set the invalid field value
            if (invalidValue == "Mexico")
                customer.Country = invalidValue;
            else if (invalidValue == "InvalidZip")
                customer.Zip = invalidValue;
            else if (invalidValue == "invalid-phone")
                customer.Phone = invalidValue;
            else if (invalidValue == "invalid-email")
                customer.Email = invalidValue;
            else
                customer.Name = invalidValue;

            var isValid = ValidateCustomer(customer, out var validationResults);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == expectedErrorMessage));
        }

        [TestMethod]
        public void Customer_MissingRequiredFields_ReturnsInvalid()
        {
            var customer = new Customer(); // All fields are empty or invalid by default
            var isValid = ValidateCustomer(customer, out var validationResults);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Name is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Email is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Phone is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "City is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "State is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Postal/Zip code is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Country is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Contact Name is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Contact Phone is required."));
            Assert.IsTrue(validationResults.Exists(vr => vr.ErrorMessage == "Contact Email is required."));
        }
    }
}


