using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Domain.Entities;
using Domain.Enums;
using MapperPattern.API.Interfaces.Mappers;

namespace MapperPattern.API.Mappers;

public sealed class CarMapper(ICarFeatureMapper carFeatureMapper, IColorMapper colorMapper,
                              IEngineMapper engineMapper) : ICarMapper
{
    private readonly ICarFeatureMapper _carFeatureMapper = carFeatureMapper;
    private readonly IColorMapper _colorMapper = colorMapper;
    private readonly IEngineMapper _engineMapper = engineMapper;

    public Car SaveRequestToDomain(CarSaveRequest carSaveRequest) =>
        new()
        {
            CarFeatures = _carFeatureMapper.SaveRequestListToDomainList(carSaveRequest.CarFeatures),
            Engine = _engineMapper.SaveRequestToDomain(carSaveRequest.Engine),
            FuelType = (EFuelType)carSaveRequest.FuelType,
            HasNavigationSystem = carSaveRequest.HasNavigationSystem,
            Model = carSaveRequest.Model,
            Price = carSaveRequest.Price,
            RegistrationDate = DateTime.UtcNow,
            Year = carSaveRequest.Year,
            Colors = []
        };

    public List<CarResponse> DomainListToResponseList(List<Car> carList) =>
        carList.Select(DomainToResponse).ToList();

    private CarResponse DomainToResponse(Car car) =>
        new()
        {
            CarFeatures = _carFeatureMapper.DomainListToResponseList(car.CarFeatures),
            Colors = _colorMapper.DomainListToResponseList(car.Colors),
            Engine = _engineMapper.DomainToResponse(car.Engine),
            FuelType = (ushort)car.FuelType,
            HasNavigationSystem = car.HasNavigationSystem,
            Id = car.Id,
            Model = car.Model,
            Price = car.Price,
            RegistrationDate = car.RegistrationDate,
            Year = car.Year
        };
}
