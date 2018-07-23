using Newtonsoft.Json;

namespace Weather_App.Classes
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}