using System.Text.Json;
using Microsoft.JSInterop;

namespace PayUnicard.Registration.Iframe.Client.Services;

public interface IIframeInteropService
{
    Task NotifyParentAsync(string eventName, object? payload = null);
    Task<string> GetRecaptchaTokenAsync(string action);
    Task<string> RegisterKycListenerAsync<T>(DotNetObjectReference<T> callback) where T : class;
    Task RemoveKycListenerAsync(string listenerId);
}

public sealed class IframeInteropService : IIframeInteropService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IAppEnvironmentService _environment;

    public IframeInteropService(IJSRuntime jsRuntime, IAppEnvironmentService environment)
    {
        _jsRuntime = jsRuntime;
        _environment = environment;
    }

    public async Task NotifyParentAsync(string eventName, object? payload = null)
    {
        if (!_environment.App.EnableParentMessaging)
        {
            return;
        }

        await _jsRuntime.InvokeVoidAsync(
            "registrationIframe.notifyParent",
            eventName,
            payload is null ? null : JsonSerializer.Serialize(payload),
            _environment.Iframe.AllowedParentOrigins);
    }

    public async Task<string> GetRecaptchaTokenAsync(string action)
    {
        if (!_environment.App.EnableRecaptcha || string.IsNullOrWhiteSpace(_environment.Recaptcha.SiteKey))
        {
            return string.Empty;
        }

        return await _jsRuntime.InvokeAsync<string>(
            "registrationIframe.getRecaptchaToken",
            _environment.Recaptcha.SiteKey,
            action);
    }

    public Task<string> RegisterKycListenerAsync<T>(DotNetObjectReference<T> callback) where T : class
        => _jsRuntime.InvokeAsync<string>(
            "registrationIframe.registerKycListener",
            callback,
            _environment.Iframe.AllowedKycOrigins,
            _environment.Iframe.CompletionEventNames).AsTask();

    public Task RemoveKycListenerAsync(string listenerId)
    {
        if (string.IsNullOrWhiteSpace(listenerId))
        {
            return Task.CompletedTask;
        }

        return _jsRuntime.InvokeVoidAsync("registrationIframe.removeKycListener", listenerId).AsTask();
    }
}
