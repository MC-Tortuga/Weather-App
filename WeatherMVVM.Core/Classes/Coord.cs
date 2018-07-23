using Newtonsoft.Json;

namespace Weather_App.Classes
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        public override string ToString()
        {
            return Lat + ", " + Lon;
        }
    }
}