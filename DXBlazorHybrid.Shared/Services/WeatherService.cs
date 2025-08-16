using System.Globalization;
using System.Net.Http.Json;

namespace DXBlazorHybrid.Shared.Services;
public class WeatherService
{
    private readonly HttpClient _httpClient;
    public WeatherService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<WeatherResult?> GetWeatherAsync(double latitude, double longitude)
    {
        var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude.ToString(CultureInfo.InvariantCulture)}&longitude={longitude.ToString(CultureInfo.InvariantCulture)}&current_weather=true";
        return await _httpClient.GetFromJsonAsync<WeatherResult>(url);
    }
}

public class WeatherResult
{
    public CurrentWeather? current_weather { get; set; }
}

public class CurrentWeather
{
    public double temperature { get; set; }
    public double windspeed { get; set; }
    public double winddirection { get; set; }
    public int weathercode { get; set; }
    public string time { get; set; }
}