using Newtonsoft.Json;

namespace CarExplorer.Dtos
{
    public class VehicleTypeDto
    {
        [JsonProperty("VehicleTypeId")]
        public int VehicleTypeId { get; set; }

        [JsonProperty("VehicleTypeName")]
        public string VehicleTypeName { get; set; }
    }
}
