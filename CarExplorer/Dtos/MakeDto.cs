using Newtonsoft.Json;

namespace CarExplorer.Dtos
{
    public class MakeDto
    {
        [JsonProperty("Make_ID")]
        public int MakeId { get; set; }

        [JsonProperty("Make_Name")]
        public string MakeName { get; set; }
    }
}
