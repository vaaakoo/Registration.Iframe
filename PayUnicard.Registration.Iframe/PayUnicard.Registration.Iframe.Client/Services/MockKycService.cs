using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public class MockKycService : IKycService
{
    public Task CheckSessionLimitWebAsync() => Task.CompletedTask;

    public Task<OpenSessionResponse?> OpenSessionAsync()
    {
        return Task.FromResult<OpenSessionResponse?>(new OpenSessionResponse 
        { 
            FrameUrl = "https://demo.kvalifika.com", 
            SessionId = "mock-session-id", 
            SkipKycSession = false 
        });
    }

    public Task<GetSessionDataResponse?> GetSessionDataAsync(string? sessionId = null)
    {
        return Task.FromResult<GetSessionDataResponse?>(new GetSessionDataResponse 
        { 
            Data = new List<KycData> 
            { 
                new KycData 
                { 
                    FirstName = "John", 
                    LastName = "Doe", 
                    PersonalNumber = "01010101010", 
                    Verified = true,
                    Status = "Completed"
                } 
            } 
        });
    }

    public Task<CloseSessionResponse?> CloseSessionAsync(string sessionId)
    {
        return Task.FromResult<CloseSessionResponse?>(new CloseSessionResponse 
        { 
            FirstName = "John", 
            LastName = "Doe", 
            PersonalNumber = "01010101010", 
            Verified = true 
        });
    }
}
