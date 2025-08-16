namespace DXBlazorHybrid.Shared.Services;

public interface ILocationService
{
    Task<LocationDto?> GetCurrentLocationAsync();
}

public class LocationDto
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
