using System;

namespace YourNamespace
{
    public partial class Weather : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {


        }



        protected void submit_Click(object sender, EventArgs e)
        {
            string city = cityval.Text;
            WeatherService weatherService = new WeatherService();
            WeatherData weatherData = weatherService.GetWeather(city);
            lblTemp.Text = $"Temperature: {weatherData.TemperatureCelsius}";
            Label1.Text = $"Wind Speed: {weatherData.WindKph }";
            Label2.Text = $"Pressure: {weatherData.PressureMb }";
            Label4.Text = $"Day: {weatherData.ConditionText }";


        }
    }

}
