namespace PayUnicard.Registration.Iframe.Client.Configuration;

public sealed class AppOptions
{
    public bool UseMockServices { get; set; }
    public bool EnableParentMessaging { get; set; } = true;
    public bool EnableRecaptcha { get; set; }
    public string Mode { get; set; } = "Production";
}

public sealed class WalletApiOptions
{
    public string BaseUrl { get; set; } = "https://papi.payunicard.ge";
}

public sealed class GoogleRecaptchaOptions
{
    public string SiteKey { get; set; } = string.Empty;
}

public sealed class IframeOptions
{
    public List<string> AllowedParentOrigins { get; set; } = [];
    public List<string> AllowedKycOrigins { get; set; } = [];
    public List<string> CompletionEventNames { get; set; } = [];
}
