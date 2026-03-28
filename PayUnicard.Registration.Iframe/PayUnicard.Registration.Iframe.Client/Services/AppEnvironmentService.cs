using Microsoft.Extensions.Options;
using PayUnicard.Registration.Iframe.Client.Configuration;

namespace PayUnicard.Registration.Iframe.Client.Services;

public interface IAppEnvironmentService
{
    AppOptions App { get; }
    WalletApiOptions WalletApi { get; }
    GoogleRecaptchaOptions Recaptcha { get; }
    IframeOptions Iframe { get; }
    bool IsMockMode { get; }
    bool IsDevelopmentMode { get; }
}

public sealed class AppEnvironmentService : IAppEnvironmentService
{
    public AppEnvironmentService(
        IMockModeService mockMode,
        IOptions<AppOptions> app,
        IOptions<WalletApiOptions> walletApi,
        IOptions<GoogleRecaptchaOptions> recaptcha,
        IOptions<IframeOptions> iframe)
    {
        _mockMode = mockMode;
        App = app.Value;
        WalletApi = walletApi.Value;
        Recaptcha = recaptcha.Value;
        Iframe = iframe.Value;
    }

    private readonly IMockModeService _mockMode;

    public AppOptions App { get; }
    public WalletApiOptions WalletApi { get; }
    public GoogleRecaptchaOptions Recaptcha { get; }
    public IframeOptions Iframe { get; }
    public bool IsMockMode => _mockMode.IsEnabled;
    public bool IsDevelopmentMode => string.Equals(App.Mode, "Development", StringComparison.OrdinalIgnoreCase);
}
