using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services
{
    public interface IOtpService
    {
        Task<SendOtpResponse?> SendPhoneOtpAsync(SendOtpRequest request, string token);
        Task<SubmitOtpResponse?> SubmitPhoneOtpAsync(SubmitOtpRequest request);
    }

    public class OtpService : IOtpService
    {
        private readonly HttpClient _httpClient;

        public OtpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SendOtpResponse?> SendPhoneOtpAsync(SendOtpRequest request, string token)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, "/api/v2/OTP/SendPhoneOTP");
            msg.Headers.Add("GoogleToken", token);
            msg.Content = JsonContent.Create(request);

            var response = await _httpClient.SendAsync(msg);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SendOtpResponse>();
        }

        public async Task<SubmitOtpResponse?> SubmitPhoneOtpAsync(SubmitOtpRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/OTP/SubmitPhoneOTP", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubmitOtpResponse>();
        }
    }
}
