namespace PayUnicard.Registration.Iframe.Client.Models;

public class SendOtpRequest
{
    public int OtpOperationType { get; set; } = 1;
    public string Phone { get; set; } = string.Empty;
}

public class SendOtpResponse
{
    public bool Success { get; set; }
}

public class SubmitOtpRequest
{
    public string Otp { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

public class SubmitOtpResponse
{
    public string OtpGuid { get; set; } = string.Empty;
}
