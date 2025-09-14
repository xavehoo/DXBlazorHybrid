using DXBlazorHybrid.Shared.Services;

namespace DXBlazorHybrid.Web.Client.Services;

public class WebLocationService : ILocationService
{
    public string? LastError { get; private set; }

    public Task<LocationDto?> GetCurrentLocationAsync()
    {
        LastError = "La geolocalizzazione non è supportata su questa piattaforma.";
        return Task.FromResult<LocationDto?>(null);
    }
}
