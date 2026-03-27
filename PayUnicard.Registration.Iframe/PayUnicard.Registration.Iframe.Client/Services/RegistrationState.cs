using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services
{
    public class RegistrationState
    {
        public UserPreRegistrationRequest PreRegistration { get; set; } = new();
        public CustomerRegistrationRequest Customer { get; set; } = new();
        public CloseSessionResponse? KycData { get; set; }
    }
}
