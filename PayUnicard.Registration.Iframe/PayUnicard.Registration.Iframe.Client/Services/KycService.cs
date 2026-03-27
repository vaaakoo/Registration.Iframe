using System.Net.Http.Json;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public interface IKycService
{
    Task CheckSessionLimitWebAsync();
    Task<OpenSessionResponse?> OpenSessionAsync();
    Task<GetSessionDataResponse?> GetSessionDataAsync(string? sessionId = null);
    Task<CloseSessionResponse?> CloseSessionAsync(string sessionId);
}

public class KycService : IKycService
{
    private readonly HttpClient _http;

    public KycService(HttpClient http) => _http = http;

    public async Task CheckSessionLimitWebAsync()
    {
        var resp = await _http.GetAsync("/api/v2/Kyc/CheckSessionLimitWeb");
        resp.EnsureSuccessStatusCode();
    }

    public async Task<OpenSessionResponse?> OpenSessionAsync()
    {
        var resp = await _http.GetAsync("/api/v2/Kyc/OpenSession");
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<OpenSessionResponse>();
    }

    public async Task<GetSessionDataResponse?> GetSessionDataAsync(string? sessionId = null)
    {
        var url = string.IsNullOrEmpty(sessionId)
            ? "/api/v2/Kyc/GetSessionData"
            : $"/api/v2/Kyc/GetSessionData?sessionId={sessionId}";
        var resp = await _http.GetAsync(url);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<GetSessionDataResponse>();
    }

    public async Task<CloseSessionResponse?> CloseSessionAsync(string sessionId)
    {
        var msg = new HttpRequestMessage(HttpMethod.Get, $"/api/v2/Kyc/CloseSession?sessionId={sessionId}");
        msg.Headers.TryAddWithoutValidation("x-options", "DateFormatISO");
        var resp = await _http.SendAsync(msg);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<CloseSessionResponse>();
    }
}
