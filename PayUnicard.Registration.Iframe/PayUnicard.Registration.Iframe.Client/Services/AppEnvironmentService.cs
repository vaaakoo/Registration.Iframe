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
        IOptions<AppOptions> app,
        IOptions<WalletApiOptions> walletApi,
        IOptions<GoogleRecaptchaOptions> recaptcha,
        IOptions<IframeOptions> iframe)
    {
        App = app.Value;
        WalletApi = walletApi.Value;
        Recaptcha = recaptcha.Value;
        Iframe = iframe.Value;
    }

    public AppOptions App { get; }
    public WalletApiOptions WalletApi { get; }
    public GoogleRecaptchaOptions Recaptcha { get; }
    public IframeOptions Iframe { get; }
    public bool IsMockMode => App.UseMockServices;
    public bool IsDevelopmentMode => string.Equals(App.Mode, "Development", StringComparison.OrdinalIgnoreCase);
}
