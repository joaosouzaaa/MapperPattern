using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;

namespace AutoMapper.API.Interfaces;

public interface ICarService
{
    Task<bool> AddAsync(CarSaveRequest carSaveRequest);
    Task<CarResponse?> GetByIdAsync(int id);
    Task<CarResponse?> GetByIdWithAllRelationshipsAsync(int id);
    Task<List<CarResponse>> GetAllAsync();
    Task<List<CarResponse>> GetAllWithAllRelationshipsAsync();
}
