using AutoMapper.API.Extensions;
using AutoMapper.API.Interfaces;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Domain.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoMapper.API.Services;

public sealed class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<bool> AddAsync(CarSaveRequest carSaveRequest)
    {
        var car = carSaveRequest.MapTo<CarSaveRequest, Car>();

        return await _carRepository.AddAsync(car);
    }

    public async Task<CarResponse?> GetByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);

        return car.MapTo<Car, CarResponse>();
    }

    public async Task<CarResponse?> GetByIdWithAllRelationshipsAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id, c => c.Include(c => c.Engine).Include(c => c.CarFeatures).Include(c => c.Colors));

        return car.MapTo<Car, CarResponse>();
    }

    public async Task<List<CarResponse>> GetAllAsync()
    {
        var carList = await _carRepository.GetAllAsync();

        return carList.MapTo<List<Car>, List<CarResponse>>();
    }

    public async Task<List<CarResponse>> GetAllWithAllRelationshipsAsync()
    {
        var carList = await _carRepository.GetAllAsync(c => c.Include(c => c.Engine).Include(c => c.CarFeatures).Include(c => c.Colors));

        return carList.MapTo<List<Car>, List<CarResponse>>();
    }
}
