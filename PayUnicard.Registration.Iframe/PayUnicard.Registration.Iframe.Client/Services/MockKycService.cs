using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public class MockKycService : IKycService
{
    private const string SampleImageBase64 =
        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==";

    public Task CheckSessionLimitWebAsync() => Task.CompletedTask;

    public Task<OpenSessionResponse?> OpenSessionAsync()
    {
        return Task.FromResult<OpenSessionResponse?>(new OpenSessionResponse 
        { 
            FrameUrl = "/mock-kyc", // Redirect to internal page for mock iframe simulation
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
                BuildMockKycData()
            } 
        });
    }

    public Task<CloseSessionResponse?> CloseSessionAsync(string sessionId)
    {
        return Task.FromResult<CloseSessionResponse?>(new CloseSessionResponse 
        { 
            FirstName = "Mock",
            LastName = "User",
            BirthDate = "1990-01-01T00:00:00",
            ExpirationDate = "2030-12-31T00:00:00",
            IssueDate = "2020-01-01T00:00:00",
            IssueDateTime = "2020-01-01T00:00:00",
            Sex = "male",
            Nationality = "American",
            DocumentNumber = "MOCK123456",
            PersonalNumber = "01001012345",
            DocumentFrontSide = SampleImageBase64,
            DocumentBackSide = SampleImageBase64,
            DocumetType = "ID",
            SelfImages = new List<string> { SampleImageBase64 },
            Verified = true,
            Status = "SUCCESS",
            CountryID = 840,
            CountryName = "United States",
            DocumentIssuingCountryID = 840
        });
    }

    private static KycData BuildMockKycData()
        => new()
        {
            FirstName = "Mock",
            LastName = "User",
            BirthDate = "1990/01/01",
            ExpirationDate = "2030/12/31",
            Sex = "male",
            Nationality = "American",
            DocumentNumber = "MOCK123456",
            PersonalNumber = "01001012345",
            DocumentFrontSide = SampleImageBase64,
            DocumentBackSide = SampleImageBase64,
            DocumetType = "ID",
            SelfImages = new List<string> { SampleImageBase64 },
            Verified = true,
            Status = "SUCCESS",
            CountryID = 840,
            CountryName = "United States",
            DocumentIssuingCountryID = 840
        };
}
