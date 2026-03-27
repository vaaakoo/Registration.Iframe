using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public class MockOtpService : IOtpService
{
    public Task<SendOtpResponse?> SendPhoneOtpAsync(SendOtpRequest request, string googleToken)
    {
        Console.WriteLine($"[MOCK] Sending OTP to {request.Phone} with token {googleToken}");
        return Task.FromResult<SendOtpResponse?>(new SendOtpResponse { Success = true });
    }

    public Task<SubmitOtpResponse?> SubmitPhoneOtpAsync(SubmitOtpRequest request)
    {
        Console.WriteLine($"[MOCK] Submitting OTP {request.Otp} for {request.Phone}");
        // Mock: 1234 is the valid OTP
        if (request.Otp == "1234")
        {
            return Task.FromResult<SubmitOtpResponse?>(new SubmitOtpResponse { OtpGuid = Guid.NewGuid().ToString() });
        }
        return Task.FromResult<SubmitOtpResponse?>(new SubmitOtpResponse { OtpGuid = string.Empty });
    }
}
