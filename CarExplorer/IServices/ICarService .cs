using CarExplorer.Dtos;

namespace CarExplorer.IServices
{
    public interface ICarService
    {
        Task<List<MakeDto>> GetAll();
        Task<List<VehicleTypeDto>> GetVehicleTypesByMakeId(int makeId);
        Task<List<ModelDto>> GetModels(int makeId, int year, string vehicleType);
    }
}
