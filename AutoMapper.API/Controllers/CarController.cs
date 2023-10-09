using AutoMapper.API.Constants.RouteConstants;
using AutoMapper.API.Interfaces;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class CarController : ControllerBase
{
    private readonly ICarService _carService;

	public CarController(ICarService carService)
	{
		_carService = carService;
	}

	[HttpPost(CarRouteConstants.AddCar)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<bool> AddAsync([FromBody] CarSaveRequest carSaveRequest) =>
		await _carService.AddAsync(carSaveRequest);

	[HttpGet(CarRouteConstants.GetCarById)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarResponse))]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<CarResponse?> GetByIdAsync([FromQuery] int id) =>
		await _carService.GetByIdAsync(id);

    [HttpGet(CarRouteConstants.GetCarByIdWithRelationships)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarResponse))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<CarResponse?> GetByIdWithAllRelationshipsAsync([FromQuery] int id) =>
        await _carService.GetByIdWithAllRelationshipsAsync(id);

	[HttpGet(CarRouteConstants.GetAllCars)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<List<CarResponse>> GetAllAsync() =>
		await _carService.GetAllAsync();

	[HttpGet(CarRouteConstants.GetAllCarsWithRelationships)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<List<CarResponse>> GetAllWithRelationshipsAsync() =>
		await _carService.GetAllWithAllRelationshipsAsync();
}
