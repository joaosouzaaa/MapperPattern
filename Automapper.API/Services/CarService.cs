using AutoMapper.API.Extensions;
using AutoMapper.API.Interfaces;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Domain.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoMapper.API.Services;

public sealed class CarService(ICarRepository carRepository, IColorFacadeService colorFacadeService) : ICarService
{
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IColorFacadeService _colorFacadeService = colorFacadeService;

    public async Task<bool> AddAsync(CarSaveRequest carSaveRequest)
    {
        var car = carSaveRequest.MapTo<CarSaveRequest, Car>();

        foreach(var colorId in  carSaveRequest.ColorIds)
        {
            var color = await _colorFacadeService.GetByIdReturnsDomainObjectAsync(colorId);

            car.Colors.Add(color); 
        }

        return await _carRepository.AddAsync(car);
    }

    public async Task<CarResponse?> GetByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);

        return car?.MapTo<Car, CarResponse>();
    }

    public async Task<CarWithRelationshipsResponse?> GetByIdWithAllRelationshipsAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id, c => c.Include(c => c.Engine)
            .Include(c => c.CarFeatures)
            .Include(c => c.Colors));

        return car?.MapTo<Car, CarWithRelationshipsResponse>();
    }

    public async Task<List<CarResponse>> GetAllAsync()
    {
        var carList = await _carRepository.GetAllAsync();

        return carList.MapTo<List<Car>, List<CarResponse>>();
    }

    public async Task<List<CarWithRelationshipsResponse>> GetAllWithAllRelationshipsAsync()
    {
        var carList = await _carRepository.GetAllAsync(c => c.Include(c => c.Engine)
            .Include(c => c.CarFeatures)
            .Include(c => c.Colors));

        return carList.MapTo<List<Car>, List<CarWithRelationshipsResponse>>();
    }
}
