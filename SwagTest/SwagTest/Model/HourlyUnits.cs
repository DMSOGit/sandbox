using Newtonsoft.Json;

namespace SwagTest.Model
{
    public class HourlyUnits
    {
        //type of time
        [JsonProperty("time")] 
        public string TypeOfTime { get; set; }

        //Temperature scale
        [JsonProperty("temperature_2m")]
        public string TemperatureScale { get; set; }
    }
}
