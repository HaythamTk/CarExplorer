using Newtonsoft.Json;

namespace CarExplorer.Dtos
{
    public class ModelDto
    {
        [JsonProperty("Model_ID")]
        public int ModelId { get; set; }

        [JsonProperty("Model_Name")]
        public string ModelName { get; set; }
    }
}
