using System.Net.Http.Json;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public interface IOtpService
{
    Task<SendOtpResponse?> SendPhoneOtpAsync(SendOtpRequest request, string googleToken);
    Task<SubmitOtpResponse?> SubmitPhoneOtpAsync(SubmitOtpRequest request);
}

public class OtpService : IOtpService
{
    private readonly HttpClient _http;

    public OtpService(HttpClient http) => _http = http;

    public async Task<SendOtpResponse?> SendPhoneOtpAsync(SendOtpRequest request, string googleToken)
    {
        var msg = new HttpRequestMessage(HttpMethod.Post, "/api/v2/OTP/SendPhoneOTP")
        {
            Content = JsonContent.Create(request)
        };
        msg.Headers.TryAddWithoutValidation("GoogleToken", googleToken);
        var resp = await _http.SendAsync(msg);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<SendOtpResponse>();
    }

    public async Task<SubmitOtpResponse?> SubmitPhoneOtpAsync(SubmitOtpRequest request)
    {
        var resp = await _http.PostAsJsonAsync("/api/v2/OTP/SubmitPhoneOTP", request);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<SubmitOtpResponse>();
    }
}
