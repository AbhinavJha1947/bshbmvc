using Newtonsoft.Json;

namespace BiharStateHousingBoard.Models
{
    public class Value
    {
        [JsonProperty("value")]
        public string? value { get; set; }
        public List<string>? Values { get; set; }
    }
}
