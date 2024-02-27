using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeatherAPI
{
    public partial class WeatherAPIPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnGetWeather_Click(object sender, EventArgs e)
        {
            await FetchWeatherAsync();

        }

        private async Task FetchWeatherAsync()
        {
            string apiKey = "b96b7755de718a1b432606c6d78ebd2c";
            string city = txtCity.Text;

            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                        // Display weather information

                        lblWeatherInfo.Text = $"Temperature: {(weatherData.Main.Temp - 273)}°C, Description: {weatherData.Weather[0].Description}";
                    }
                    else
                    {
                        lblWeatherInfo.Text = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    lblWeatherInfo.Text = $"Exception: {ex.Message}";
                }
            }

        }
        public class WeatherData
        {
            public MainData Main { get; set; }
            public WeatherInfo[] Weather { get; set; }
        }

        public class MainData
        {
            public float Temp { get; set; }
        }

        public class WeatherInfo
        {
            public string Description { get; set; }

        }
    }
}