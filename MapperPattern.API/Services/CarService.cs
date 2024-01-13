using DataTransferObjects.Requests.Car;
using Infra.Interfaces;
using MapperPattern.API.Interfaces.Mappers;
using MapperPattern.API.Interfaces.Services;

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

            car.Colors.Add(color);
        }

        return await _carRepository.AddAsync(car);
    }


}
