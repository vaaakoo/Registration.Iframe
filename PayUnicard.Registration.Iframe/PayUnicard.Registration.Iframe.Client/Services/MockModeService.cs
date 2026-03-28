using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using PayUnicard.Registration.Iframe.Client.Configuration;

namespace PayUnicard.Registration.Iframe.Client.Services;

public interface IMockModeService
{
    bool IsEnabled { get; }
    string Source { get; }
}

public sealed class MockModeService : IMockModeService
{
    public MockModeService(IOptions<AppOptions> appOptions, NavigationManager navigationManager)
    {
        var query = new Uri(navigationManager.Uri).Query;
        if (TryGetQueryFlag(query, "mock", out var queryFlag))
        {
            IsEnabled = queryFlag;
            Source = "query";
            return;
        }

        IsEnabled = appOptions.Value.UseMockServices;
        Source = IsEnabled ? "config" : "disabled";
    }

    public bool IsEnabled { get; }
    public string Source { get; }

    private static bool TryGetQueryFlag(string query, string key, out bool value)
    {
        value = false;
        if (string.IsNullOrWhiteSpace(query))
        {
            return false;
        }

        foreach (var pair in query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = pair.Split('=', 2);
            if (parts.Length == 0)
            {
                continue;
            }

            var name = Uri.UnescapeDataString(parts[0]);
            if (!string.Equals(name, key, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var raw = parts.Length > 1 ? Uri.UnescapeDataString(parts[1]) : string.Empty;
            value = raw is "" or "1" or "true" or "yes" or "on";
            return true;
        }

        return false;
    }
}
