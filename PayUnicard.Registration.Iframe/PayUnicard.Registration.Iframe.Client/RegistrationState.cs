using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client;

public class RegistrationState
{
    public UserPreRegistrationRequest PreRegistration { get; set; } = new();
    public CustomerRegistrationRequest CustomerInfo { get; set; } = new();
    public string SessionId { get; set; } = string.Empty;
    public KycData? KycData { get; set; }
}
