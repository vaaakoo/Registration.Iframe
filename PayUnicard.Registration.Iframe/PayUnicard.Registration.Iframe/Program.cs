using Microsoft.Extensions.Options;
using PayUnicard.Registration.Iframe.Client.Configuration;
using PayUnicard.Registration.Iframe.Client.Models;
using PayUnicard.Registration.Iframe.Client.Services;
using PayUnicard.Registration.Iframe.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("App"));
builder.Services.Configure<WalletApiOptions>(builder.Configuration.GetSection("WalletApi"));
builder.Services.Configure<GoogleRecaptchaOptions>(builder.Configuration.GetSection("GoogleRecaptcha"));
builder.Services.Configure<IframeOptions>(builder.Configuration.GetSection("Iframe"));

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var appSection = builder.Configuration.GetSection("App");
var useMockServices = true;
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

builder.Services.AddScoped<IAppEnvironmentService, AppEnvironmentService>();
builder.Services.AddScoped<IIframeInteropService, IframeInteropService>();
builder.Services.AddScoped<IMockModeService, MockModeService>();
builder.Services.AddScoped<PayUnicard.Registration.Iframe.Client.Services.RegistrationState>();

var walletApiOptions = builder.Configuration.GetSection("WalletApi").Get<WalletApiOptions>() ?? new WalletApiOptions();
builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(walletApiOptions.BaseUrl)
});

var iframeOptions = builder.Configuration.GetSection("Iframe").Get<IframeOptions>() ?? new IframeOptions();
var allowedOrigins = iframeOptions.AllowedParentOrigins
    .Where(origin => !string.IsNullOrWhiteSpace(origin))
    .Distinct(StringComparer.OrdinalIgnoreCase)
    .ToArray();

builder.Services.AddCors(options =>
{
    options.AddPolicy("IframePolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod();

        if (allowedOrigins.Length > 0)
        {
            policy.WithOrigins(allowedOrigins);
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

var appOptions = app.Services.GetRequiredService<IOptions<AppOptions>>().Value;
var frameAncestors = allowedOrigins.Length > 0
    ? string.Join(" ", allowedOrigins)
    : "'self'";

var scriptSources = new List<string>
{
    "'self'",
    "'unsafe-inline'",
    "'wasm-unsafe-eval'"
};

if (app.Environment.IsDevelopment())
{
    scriptSources.Add("'unsafe-eval'");
}

if (appOptions.EnableRecaptcha)
{
    scriptSources.Add("https://www.google.com");
    scriptSources.Add("https://www.gstatic.com");
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("X-Frame-Options");
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";

    var connectSources = new List<string>
    {
        "'self'",
        walletApiOptions.BaseUrl
    };

    if (app.Environment.IsDevelopment())
    {
        connectSources.Add("http://localhost:*");
        connectSources.Add("https://localhost:*");
        connectSources.Add("ws://localhost:*");
    }

    var frameSources = iframeOptions.AllowedKycOrigins.Count > 0
        ? string.Join(" ", iframeOptions.AllowedKycOrigins)
        : "https://api.kvalifika.com https://sdk.kvalifika.com";

    var csp = string.Join(" ", new[]
    {
        "default-src 'self';",
        "base-uri 'self';",
        "object-src 'none';",
        $"script-src {string.Join(" ", scriptSources)};",
        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com;",
        "font-src 'self' https://fonts.gstatic.com;",
        $"frame-src {frameSources};",
        "img-src 'self' data: blob:;",
        $"connect-src {string.Join(" ", connectSources)};",
        $"frame-ancestors {frameAncestors};"
    });

    context.Response.Headers["Content-Security-Policy"] = csp;

    await next();
});

app.UseRouting();
app.UseCors("IframePolicy");
app.UseAntiforgery();
app.UseHttpsRedirection();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(UserPreRegistrationRequest).Assembly);

app.Run();
