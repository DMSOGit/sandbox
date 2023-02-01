using Newtonsoft.Json;

namespace SwagTest.Model
{
    public class WeatherData
    {        
        public float latitude { get; set; }
        public float longitude { get; set; }
        [JsonProperty("generationtime_ms")]
        public float generationtimeMs { get; set; }
        [JsonProperty("utc_offset_seconds")]
        public int utcOffsetSeconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public float elevation { get; set; }
        public HourlyUnits hourly_units { get; set; }
        public HourlyData hourly { get; set; }
    }
}
