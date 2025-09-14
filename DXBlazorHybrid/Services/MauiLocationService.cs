using DXBlazorHybrid.Shared.Services;
using Microsoft.Maui.Devices.Sensors;
using System.Diagnostics;

namespace DXBlazorHybrid.Services;

public class MauiLocationService : ILocationService
{
    public string? LastError { get; private set; }

    public async Task<LocationDto?> GetCurrentLocationAsync()
    {
        LastError = null;
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync()
                ?? await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            if (location == null)
            {
                LastError = "Impossibile ottenere la posizione: nessun dato disponibile.";
                return null;
            }
            return new LocationDto { Latitude = location.Latitude, Longitude = location.Longitude };
        }
        catch (Exception ex)
        {
            LastError = $"Errore geolocalizzazione: {ex.Message}";
            Debug.WriteLine($"[LocationService] {ex}");
            return null;
        }
    }
}
