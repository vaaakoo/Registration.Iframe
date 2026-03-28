using PayUnicard.Registration.Iframe.Client.Models;

namespace PayUnicard.Registration.Iframe.Client.Services;

public sealed class UserServiceRouter : IUserService
{
    private readonly IUserService _real;
    private readonly IUserService _mock;
    private readonly IMockModeService _mockMode;

    public UserServiceRouter(UserService real, MockUserService mock, IMockModeService mockMode)
    {
        _real = real;
        _mock = mock;
        _mockMode = mockMode;
    }

    private IUserService Current => _mockMode.IsEnabled ? _mock : _real;

    public Task<CheckUserResponse?> CheckUserPreRegistrationAsync(CheckUserRequest request)
        => Current.CheckUserPreRegistrationAsync(request);

    public Task<UserPreRegistrationResponse?> UserPreRegistrationAsync(UserPreRegistrationRequest request)
        => Current.UserPreRegistrationAsync(request);

    public Task<CustomerRegistrationResponse?> CustomerRegistrationAsync(CustomerRegistrationRequest request)
        => Current.CustomerRegistrationAsync(request);

    public Task<FinishCustomerRegistrationResponse?> FinishCustomerRegistrationAsync(FinishCustomerRegistrationRequest request)
        => Current.FinishCustomerRegistrationAsync(request);

    public Task<ChangeCustomerResponse?> ChangeCustomerAsync(ChangeCustomerRequest request)
        => Current.ChangeCustomerAsync(request);
}

public sealed class OtpServiceRouter : IOtpService
{
    private readonly IOtpService _real;
    private readonly IOtpService _mock;
    private readonly IMockModeService _mockMode;

    public OtpServiceRouter(OtpService real, MockOtpService mock, IMockModeService mockMode)
    {
        _real = real;
        _mock = mock;
        _mockMode = mockMode;
    }

    private IOtpService Current => _mockMode.IsEnabled ? _mock : _real;

    public Task<SendOtpResponse?> SendPhoneOtpAsync(SendOtpRequest request, string googleToken)
        => Current.SendPhoneOtpAsync(request, googleToken);

    public Task<SubmitOtpResponse?> SubmitPhoneOtpAsync(SubmitOtpRequest request)
        => Current.SubmitPhoneOtpAsync(request);
}

public sealed class KycServiceRouter : IKycService
{
    private readonly IKycService _real;
    private readonly IKycService _mock;
    private readonly IMockModeService _mockMode;

    public KycServiceRouter(KycService real, MockKycService mock, IMockModeService mockMode)
    {
        _real = real;
        _mock = mock;
        _mockMode = mockMode;
    }

    private IKycService Current => _mockMode.IsEnabled ? _mock : _real;

    public Task CheckSessionLimitWebAsync() => Current.CheckSessionLimitWebAsync();
    public Task<OpenSessionResponse?> OpenSessionAsync() => Current.OpenSessionAsync();
    public Task<GetSessionDataResponse?> GetSessionDataAsync(string? sessionId = null) => Current.GetSessionDataAsync(sessionId);
    public Task<CloseSessionResponse?> CloseSessionAsync(string sessionId) => Current.CloseSessionAsync(sessionId);
}

public sealed class PresentationServiceRouter : IPresentationService
{
    private readonly IPresentationService _real;
    private readonly IPresentationService _mock;
    private readonly IMockModeService _mockMode;

    public PresentationServiceRouter(PresentationService real, MockPresentationService mock, IMockModeService mockMode)
    {
        _real = real;
        _mock = mock;
        _mockMode = mockMode;
    }

    private IPresentationService Current => _mockMode.IsEnabled ? _mock : _real;

    public Task<CitizenshipCountriesResponse?> GetCitizenshipCountriesAsync() => Current.GetCitizenshipCountriesAsync();
    public Task<WorkTypesResponse?> GetCustomerWorkTypesAsync() => Current.GetCustomerWorkTypesAsync();
    public Task<EmploymentStatusResponse?> GetCustomerEmploymentStatusTypesAsync() => Current.GetCustomerEmploymentStatusTypesAsync();
    public Task<ExpectedTransactionTypesResponse?> GetExpectedTransactionTypesAsync() => Current.GetExpectedTransactionTypesAsync();
    public Task<AnnualIncomeResponse?> GetCustomerAnnualIncomeTypesAsync() => Current.GetCustomerAnnualIncomeTypesAsync();
    public Task<UsagePurposeResponse?> GetCustomerUsagePurposeAsync() => Current.GetCustomerUsagePurposeAsync();
    public Task<OtpSourcesResponse?> GetOtpSourcesAsync() => Current.GetOtpSourcesAsync();
}
