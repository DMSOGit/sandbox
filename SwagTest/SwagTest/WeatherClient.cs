using System.Net;

namespace SwagTest
{
    public class WeatherClient
    {
        private const string API_URL = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly=temperature_2m";
        private readonly HttpClient _client;

        //Singleton, dont instanciate
        public WeatherClient(HttpClient client) 
        {
            _client = client;
        }
        public string GetWeatherData(string latitude, string longitude)
        {
            string data;
            string url = string.Format(API_URL, latitude, longitude);
            HttpResponseMessage response = _client.GetAsync(url).Result;
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
