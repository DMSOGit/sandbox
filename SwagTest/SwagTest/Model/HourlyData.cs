using Newtonsoft.Json;

namespace SwagTest.Model
{
    public class HourlyData
    {
        public List<string> time { get; set; }

        [JsonProperty("temperature_2m")]
        public List<float> temperature { get; set; }
    }
}
