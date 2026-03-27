using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PayUnicard.Registration.Iframe.Client;
using PayUnicard.Registration.Iframe.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.RootComponents.Add<App>("#app"); // 🔥 MUST

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://papi.payunicard.ge") });

builder.Services.AddScoped<IUserService, MockUserService>();
builder.Services.AddScoped<IOtpService, MockOtpService>();
builder.Services.AddScoped<IKycService, MockKycService>();
builder.Services.AddScoped<IPresentationService, MockPresentationService>();
builder.Services.AddScoped<PayUnicard.Registration.Iframe.Client.RegistrationState>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();