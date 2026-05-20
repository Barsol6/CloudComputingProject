using System.Net.Http.Json;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public WeatherService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        string? apiKey = _config["ApiKeys:WeatherApi"];
        
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pl";

        return await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
    }
}