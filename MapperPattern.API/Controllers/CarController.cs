using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Microsoft.AspNetCore.Mvc;
using MapperPattern.API.Interfaces.Services;
using Domain.Constants.RouteConstants;

namespace MapperPattern.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class CarController(ICarService carService) : ControllerBase
{
    private readonly ICarService _carService = carService;

    [HttpPost(CarRouteConstants.AddCar)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] CarSaveRequest carSaveRequest) =>
        _carService.AddAsync(carSaveRequest);

    [HttpGet(CarRouteConstants.GetCarById)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarResponse))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<CarResponse?> GetByIdAsync([FromQuery] int id) =>
        _carService.GetByIdAsync(id);

    [HttpGet(CarRouteConstants.GetCarByIdWithRelationships)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarWithRelationshipsResponse))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<CarWithRelationshipsResponse?> GetByIdWithAllRelationshipsAsync([FromQuery] int id) =>
        _carService.GetByIdWithAllRelationshipsAsync(id);

    [HttpGet(CarRouteConstants.GetAllCars)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CarResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<CarResponse>> GetAllAsync() =>
        _carService.GetAllAsync();

    [HttpGet(CarRouteConstants.GetAllCarsWithRelationships)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CarWithRelationshipsResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<CarWithRelationshipsResponse>> GetAllWithRelationshipsAsync() =>
        _carService.GetAllWithAllRelationshipsAsync();
}
