using System.Net.Http.Json;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public interface IReferenceDataService
{
    Task<CitizenshipCountriesResponse?> GetCitizenshipCountriesAsync();
    Task<WorkTypesResponse?> GetCustomerWorkTypesAsync();
    Task<EmploymentStatusResponse?> GetCustomerEmploymentStatusTypesAsync();
    Task<ExpectedTransactionTypesResponse?> GetExpectedTransactionTypesAsync();
    Task<AnnualIncomeResponse?> GetCustomerAnnualIncomeTypesAsync();
    Task<UsagePurposeResponse?> GetCustomerUsagePurposeAsync();
    Task<OtpSourcesResponse?> GetOtpSourcesAsync();
}

public class ReferenceDataService : IReferenceDataService
{
    private readonly HttpClient _http;

    public ReferenceDataService(HttpClient http) => _http = http;

    public Task<CitizenshipCountriesResponse?> GetCitizenshipCountriesAsync()
        => _http.GetFromJsonAsync<CitizenshipCountriesResponse>("/api/v2/GetCitizenshipCountries");

    public Task<WorkTypesResponse?> GetCustomerWorkTypesAsync()
        => _http.GetFromJsonAsync<WorkTypesResponse>("/api/v2/User/GetCustomerWorkTypes");

    public Task<EmploymentStatusResponse?> GetCustomerEmploymentStatusTypesAsync()
        => _http.GetFromJsonAsync<EmploymentStatusResponse>("/api/v2/User/GetCustomerEmploymentStatusTypes");

    public Task<ExpectedTransactionTypesResponse?> GetExpectedTransactionTypesAsync()
        => _http.GetFromJsonAsync<ExpectedTransactionTypesResponse>("/api/v2/GetExpectedTransactionTypes");

    public Task<AnnualIncomeResponse?> GetCustomerAnnualIncomeTypesAsync()
        => _http.GetFromJsonAsync<AnnualIncomeResponse>("/api/v2/User/GetCustomerAnnualIncomeTypes");

    public Task<UsagePurposeResponse?> GetCustomerUsagePurposeAsync()
        => _http.GetFromJsonAsync<UsagePurposeResponse>("/api/v2/User/GetCustomerUsagePurpose");

    public Task<OtpSourcesResponse?> GetOtpSourcesAsync()
        => _http.GetFromJsonAsync<OtpSourcesResponse>("/api/v2/OTP/Sources");
}
