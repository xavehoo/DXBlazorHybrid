using DXBlazorHybrid.Shared.Services;

namespace DXBlazorHybrid.Web.Client.Services;

public class WebLocationService : ILocationService
{
    public Task<LocationDto?> GetCurrentLocationAsync()
    {
        // Stub: WebAssembly non supporta Geolocation nativamente qui
        return Task.FromResult<LocationDto?>(null);
    }
}
