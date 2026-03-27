using PayUnicard.Registration.Iframe.Client.Models;
using PayUnicard.Registration.Iframe.Client.Services;
using PayUnicard.Registration.Iframe.Components;

var builder = WebApplication.CreateBuilder(args);

// ── Services ──────────────────────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IKycService, KycService>();
builder.Services.AddScoped<IPresentationService, PresentationService>();
builder.Services.AddScoped<RegistrationState>();

var apiBase = builder.Configuration["WalletApi:BaseUrl"] ?? "https://papi.payunicard.ge";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBase)
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("IframePolicy", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// ── Middleware ────────────────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// 🔐 CSP
app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("X-Frame-Options");

    context.Response.Headers.Append("Content-Security-Policy",
        "default-src 'self' https://papi.payunicard.ge; " +
        "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://www.google.com https://www.gstatic.com; " +
        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com; " +
        "font-src 'self' https://fonts.gstatic.com; " +
        "frame-src https://api.kvalifika.com https://sdk.kvalifika.com https://*.kvalifika.com; " +
        "img-src 'self' data: blob:; " +
        "connect-src 'self' https://papi.payunicard.ge ws://localhost:* https://localhost:* https://raw.githubusercontent.com;");

    await next();
});

app.UseRouting();

app.UseCors("IframePolicy");

app.UseAntiforgery(); // must be after routing

app.UseHttpsRedirection();

// ✅ ONLY THIS (correct for .NET 10)
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(UserPreRegistrationRequest).Assembly);

app.Run();