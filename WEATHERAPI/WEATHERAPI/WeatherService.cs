using System;
using System.Net;
using Newtonsoft.Json;

public class WeatherService
{

    private const string BaseUrl = "http://api.weatherapi.com/v1/current.json?key=036a1a16f56b4f5c99255051242602";
    public WeatherData GetWeather(string city)
    {
        string url = $"{BaseUrl}&q={city}";
        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);
            dynamic response = JsonConvert.DeserializeObject(json);
            var weatherData = new WeatherData
            {
                TemperatureCelsius = response.current.temp_c,
                WindKph = response.current.wind_kph,
                PressureMb = response.current.pressure_mb,
                ConditionText = response.current.condition.text,
                ConditionIcon = response.current.condition.icon
            };
            return weatherData;
        }
    }
}
public class WeatherData
{
    public double TemperatureCelsius { get; set; }
    public double WindKph { get; set; }
    public int PressureMb { get; set; }
    public string ConditionText { get; set; }
    public string ConditionIcon { get; set; }
}





