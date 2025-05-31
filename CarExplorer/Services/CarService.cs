using CarExplorer.Dtos;
using CarExplorer.IServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarExplorer.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;
        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<MakeDto>> GetAll()
        {
            var json = await _httpClient.GetStringAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
            var response = JsonConvert.DeserializeObject<ApiResponse<MakeDto>>(json);

            return response?.Results ?? new List<MakeDto>();
        }

        public async Task<List<ModelDto>> GetModels(int makeId, int year, string vehicleType)
        {
            var url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}/vehicletype/{vehicleType}?format=json";
            var json = await _httpClient.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<ApiResponse<ModelDto>>(json);

            return response?.Results?? new List<ModelDto>();
        }

        public async Task<List<VehicleTypeDto>> GetVehicleTypesByMakeId(int makeId)
        {
            var url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json";
            var json = await _httpClient.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<ApiResponse<VehicleTypeDto>>(json);
            return response?.Results ?? new();
        }
    }
}
