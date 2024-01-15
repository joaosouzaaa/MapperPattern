using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Infra.Interfaces;
using MapperPattern.API.Interfaces.Mappers;
using MapperPattern.API.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace MapperPattern.API.Services;

public sealed class CarService(ICarRepository carRepository, ICarMapper carMapper,
                               IColorFacadeService colorFacadeService) : ICarService
{
    private readonly ICarRepository _carRepository = carRepository;
    private readonly ICarMapper _carMapper = carMapper;
    private readonly IColorFacadeService _colorFacadeService = colorFacadeService;

    public async Task<bool> AddAsync(CarSaveRequest carSaveRequest)
    {
        var car = _carMapper.SaveRequestToDomain(carSaveRequest);

        foreach(var colorId in carSaveRequest.ColorIds)
        {
            var color = await _colorFacadeService.GetByIdReturnsDomainObjectAsync(colorId);

            if (color is null)
                return false;

            car.Colors.Add(color);
        }

        return await _carRepository.AddAsync(car);
    }

    public async Task<CarResponse?> GetByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);

        if (car is null)
            return null;

        return _carMapper.DomainToResponse(car);
    }

    public async Task<CarWithRelationshipsResponse?> GetByIdWithAllRelationshipsAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id, c => c.Include(c => c.Engine)
            .Include(c => c.CarFeatures)
            .Include(c => c.Colors));

        if(car is null)
            return null;

        return _carMapper.DomainToWithRelationshipsResponse(car);
    }

    public async Task<List<CarResponse>> GetAllAsync()
    {
        var carList = await _carRepository.GetAllAsync();

        return _carMapper.DomainListToResponseList(carList);
    }

    public async Task<List<CarWithRelationshipsResponse>> GetAllWithAllRelationshipsAsync()
    {
        var carList = await _carRepository.GetAllAsync(c => c.Include(c => c.Engine)
            .Include(c => c.CarFeatures)
            .Include(c => c.Colors));

        return _carMapper.DomainListToWithRelationshipsResponseList(carList);
    }
}
