using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services
{
    public interface IUserService
    {
        Task<CheckUserResponse?> CheckUserPreRegistrationAsync(CheckUserRequest request);
        Task<UserPreRegistrationResponse?> UserPreRegistrationAsync(UserPreRegistrationRequest request);
        Task<CustomerRegistrationResponse?> CustomerRegistrationAsync(CustomerRegistrationRequest request);
        Task<FinishCustomerRegistrationResponse?> FinishCustomerRegistrationAsync(FinishCustomerRegistrationRequest request);
        Task<ChangeCustomerResponse?> ChangeCustomerAsync(ChangeCustomerRequest request);
    }
    
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CheckUserResponse?> CheckUserPreRegistrationAsync(CheckUserRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/User/CheckUserPreRegistration", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CheckUserResponse>();
        }

        public async Task<UserPreRegistrationResponse?> UserPreRegistrationAsync(UserPreRegistrationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/User/UserPreRegistration", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserPreRegistrationResponse>();
        }

        public async Task<CustomerRegistrationResponse?> CustomerRegistrationAsync(CustomerRegistrationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/User/Registration/CustomerRegistration", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CustomerRegistrationResponse>();
        }

        public async Task<FinishCustomerRegistrationResponse?> FinishCustomerRegistrationAsync(FinishCustomerRegistrationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/User/FinishCustomerRegistration", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FinishCustomerRegistrationResponse>();
        }

        public async Task<ChangeCustomerResponse?> ChangeCustomerAsync(ChangeCustomerRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/User/ChangeCustomer", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ChangeCustomerResponse>();
        }
    }
}
