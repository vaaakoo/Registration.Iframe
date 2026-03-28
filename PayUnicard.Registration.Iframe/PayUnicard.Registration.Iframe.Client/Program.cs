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

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OtpService>();
builder.Services.AddScoped<KycService>();
builder.Services.AddScoped<PresentationService>();
builder.Services.AddScoped<MockUserService>();
builder.Services.AddScoped<MockOtpService>();
builder.Services.AddScoped<MockKycService>();
builder.Services.AddScoped<MockPresentationService>();

builder.Services.AddScoped<IUserService, UserServiceRouter>();
builder.Services.AddScoped<IOtpService, OtpServiceRouter>();
builder.Services.AddScoped<IKycService, KycServiceRouter>();
builder.Services.AddScoped<IPresentationService, PresentationServiceRouter>();

builder.Services.AddScoped<PayUnicard.Registration.Iframe.Client.Services.RegistrationState>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
