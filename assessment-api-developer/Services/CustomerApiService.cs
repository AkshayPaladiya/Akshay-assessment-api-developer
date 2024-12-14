using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using assessment_platform_developer.Models;

namespace assessment_platform_developer.Services
{
    public interface ICustomerApiService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(int customerId, Customer customer);
        Task<bool> DeleteCustomerAsync(int customerId);
    }

    public class CustomerApiService : ICustomerApiService
    {
        // Hardcoding the base URL directly in the service
        private readonly string _baseUrl = "https://localhost:44358/"; // Example base URL (update it as needed)
        private readonly HttpClient _httpClient;

        public CustomerApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        // Get all customers from the API
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/customers").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Customer>>(content);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve customers.", ex);
            }
        }

        // Get a customer by ID
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/customers/{customerId}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(content);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve customer.", ex);
            }
        }

        // Add a new customer
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("api/customers", content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add customer.", ex);
            }
        }

        // Update an existing customer
        public async Task<Customer> UpdateCustomerAsync(int customerId, Customer customer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PutAsync($"api/customers/{customerId}", content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update customer.", ex);
            }
        }

        // Delete a customer
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/customers/{customerId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete customer.", ex);
            }
        }
    }
}
