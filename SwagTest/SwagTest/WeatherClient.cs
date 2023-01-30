using System.Net;

namespace SwagTest
{
    public class WeatherClient
    {
        private const string API_URL = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly=temperature_2m";
        private readonly HttpClient client = new HttpClient();

        public string GetWeatherData(string latitude, string longitude)
        {
            string data;
            string url = string.Format(API_URL, latitude, longitude);
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                data = "Error occured";
            }
            return data;
        }
    }
}
