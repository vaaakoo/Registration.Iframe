using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services
{
    public interface IKycService
    {
        Task CheckSessionLimitWebAsync();
        Task<OpenSessionResponse?> OpenSessionAsync();
        Task<GetSessionDataResponse?> GetSessionDataAsync(string? sessionId = null);
        Task<CloseSessionResponse?> CloseSessionAsync(string sessionId, string? accessToken = null);
    }

    public class KycService : IKycService
    {
        private readonly HttpClient _httpClient;

        public KycService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CheckSessionLimitWebAsync()
        {
            var response = await _httpClient.GetAsync("/api/v2/Kyc/CheckSessionLimitWeb");
            response.EnsureSuccessStatusCode();
        }

        public async Task<OpenSessionResponse?> OpenSessionAsync()
        {
            var response = await _httpClient.GetAsync("/api/v2/Kyc/OpenSession");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OpenSessionResponse>();
        }

        public async Task<GetSessionDataResponse?> GetSessionDataAsync(string? sessionId = null)
        {
            var url = string.IsNullOrEmpty(sessionId) ? "/api/v2/Kyc/GetSessionData" : $"/api/v2/Kyc/GetSessionData?sessionId={sessionId}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetSessionDataResponse>();
        }

        public async Task<CloseSessionResponse?> CloseSessionAsync(string sessionId, string? accessToken = null)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, $"/api/v2/Kyc/CloseSession?sessionId={sessionId}");
            msg.Headers.Add("x-options", "DateFormatISO");
            if (!string.IsNullOrEmpty(accessToken)) 
            {
                msg.Headers.Add("Authorization", accessToken);
            }

            var response = await _httpClient.SendAsync(msg);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CloseSessionResponse>();
        }
    }
}
