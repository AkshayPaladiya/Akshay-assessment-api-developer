using assessment_platform_developer.Models;
using assessment_platform_developer.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace assessment_platform_developer.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;

        // Static variable to track the next available ID (useful for in-memory storage)
        private static int _nextId = 1;

        // Inject ICustomerService via constructor
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        [Route("")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        // GET api/customers/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid customer data.");
            }

            // Assign a new ID to the customer
            customer.ID = _nextId++; // Assign and increment the ID for the next customer

            // Add customer using the service layer
            _customerService.AddCustomer(customer);

            // Return the newly created customer
            return Ok(customer);
        }

        // PUT api/customers/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (customer == null || customer.ID != id)
            {
                return BadRequest("Customer data is invalid.");
            }

            var existingCustomer = _customerService.GetCustomer(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerService.UpdateCustomer(customer);
            return Ok(customer);
        }

        // DELETE api/customers/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
