using System.Text.Json.Serialization;
using System.Collections.Generic;

public class WeatherResponse
{
    [JsonPropertyName("name")]
    public string CityName { get; set; }

    [JsonPropertyName("main")]
    public MainData Main { get; set; }

    [JsonPropertyName("weather")]
    public List<WeatherDescription> Weather { get; set; }
}

public class MainData
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
}

public class WeatherDescription
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; } 
}