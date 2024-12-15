using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace assessment_platform_developer.Models
{

	

	[Serializable]
    public class Customer
    {
        [JsonProperty("id")]
        public int ID { get; set; }

       
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

       
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\+?\d{1,4}?[\d\s\-()]*\d+$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

       
        [Required(ErrorMessage = "Postal/Zip code is required.")]
        [RegularExpression(@"(^\d{5}(-\d{4})?$)|(^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$)",
            ErrorMessage = "Invalid zip/postal code format.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [RegularExpression(@"^(Canada|United States)$", ErrorMessage = "Country must be either 'Canada' or 'United States'.")]
        public string Country { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Contact Name is required.")]
        public string ContactName { get; set; }

        
        [Required(ErrorMessage = "Contact Phone is required.")]
        [RegularExpression(@"^\+?\d{1,4}?[\d\s\-()]*\d+$", ErrorMessage = "Invalid phone number format.")]
        public string ContactPhone { get; set; }

        
        [Required(ErrorMessage = "Contact Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string ContactEmail { get; set; }
        public string ContactTitle { get; set; }
        public string ContactNotes { get; set; }
    }


  
	public class CustomerDBContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
	}
}