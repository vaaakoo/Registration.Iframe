using System.Net.Http.Json;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

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
    private readonly HttpClient _http;

    public UserService(HttpClient http) => _http = http;

    public async Task<CheckUserResponse?> CheckUserPreRegistrationAsync(CheckUserRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/v2/User/CheckUserPreRegistration", request);
        return resp.IsSuccessStatusCode ? await resp.Content.ReadFromJsonAsync<CheckUserResponse>() : null;
    }

    public async Task<UserPreRegistrationResponse?> UserPreRegistrationAsync(UserPreRegistrationRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/v2/User/UserPreRegistration", request);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<UserPreRegistrationResponse>();
    }

    public async Task<CustomerRegistrationResponse?> CustomerRegistrationAsync(CustomerRegistrationRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/v2/User/Registration/CustomerRegistration", request);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<CustomerRegistrationResponse>();
    }

    public async Task<FinishCustomerRegistrationResponse?> FinishCustomerRegistrationAsync(FinishCustomerRegistrationRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/v2/User/FinishCustomerRegistration", request);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<FinishCustomerRegistrationResponse>();
    }

    public async Task<ChangeCustomerResponse?> ChangeCustomerAsync(ChangeCustomerRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/v2/User/ChangeCustomer", request);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<ChangeCustomerResponse>();
    }
}
