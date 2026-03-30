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
builder.Services.AddScoped<IMockModeService, MockModeService>();

var walletApiOptions = builder.Configuration.GetSection("WalletApi").Get<WalletApiOptions>() ?? new WalletApiOptions();

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(walletApiOptions.BaseUrl)
});

var appSection = builder.Configuration.GetSection("App");
var useMockServices = true; // Default to mock
if (appSection.Exists() && appSection.GetChildren().Any(x => x.Key == "UseMockServices"))
{
    useMockServices = appSection.GetValue<bool>("UseMockServices");
}

if (useMockServices)
{
    builder.Services.AddScoped<IUserService, MockUserService>();
    builder.Services.AddScoped<IKycService, MockKycService>();
    builder.Services.AddScoped<IReferenceDataService, MockReferenceDataService>();
}
else
{
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IKycService, KycService>();
    builder.Services.AddScoped<IReferenceDataService, ReferenceDataService>();
}

builder.Services.AddScoped<PayUnicard.Registration.Iframe.Client.Services.RegistrationState>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
