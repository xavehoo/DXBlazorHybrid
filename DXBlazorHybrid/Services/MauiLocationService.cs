using DXBlazorHybrid.Shared.Services;
using Microsoft.Maui.Devices.Sensors;

namespace DXBlazorHybrid.Services;

public class MauiLocationService : ILocationService
{
    public async Task<LocationDto?> GetCurrentLocationAsync()
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync()
                ?? await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            if (location == null)
                return null;
            return new LocationDto { Latitude = location.Latitude, Longitude = location.Longitude };
        }
        catch
        {
            return null;
        }
    }
}
