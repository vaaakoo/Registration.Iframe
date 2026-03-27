using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PayUnicard.Registration.Iframe.Client.Configuration;
using PayUnicard.Registration.Iframe.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("App"));
builder.Services.Configure<WalletApiOptions>(builder.Configuration.GetSection("WalletApi"));
builder.Services.Configure<GoogleRecaptchaOptions>(builder.Configuration.GetSection("GoogleRecaptcha"));
builder.Services.Configure<IframeOptions>(builder.Configuration.GetSection("Iframe"));
builder.Services.AddScoped<IAppEnvironmentService, AppEnvironmentService>();
builder.Services.AddScoped<IIframeInteropService, IframeInteropService>();

var walletApiOptions = builder.Configuration.GetSection("WalletApi").Get<WalletApiOptions>() ?? new WalletApiOptions();
var appOptions = builder.Configuration.GetSection("App").Get<AppOptions>() ?? new AppOptions();

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(walletApiOptions.BaseUrl)
});

if (appOptions.UseMockServices)
{
    builder.Services.AddScoped<IUserService, MockUserService>();
    builder.Services.AddScoped<IOtpService, MockOtpService>();
    builder.Services.AddScoped<IKycService, MockKycService>();
    builder.Services.AddScoped<IPresentationService, MockPresentationService>();
}
else
{
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IOtpService, OtpService>();
    builder.Services.AddScoped<IKycService, KycService>();
    builder.Services.AddScoped<IPresentationService, PresentationService>();
}

builder.Services.AddScoped<PayUnicard.Registration.Iframe.Client.Services.RegistrationState>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
