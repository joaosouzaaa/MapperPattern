using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Constants.RouteConstants;
using MapperPattern.API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ColorController(IColorService colorService) : ControllerBase
{
    private readonly IColorService _colorService = colorService;

    [HttpPost(ColorRouteConstants.AddColor)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] ColorSaveRequest colorSaveRequest) =>
        _colorService.AddAsync(colorSaveRequest);

    [HttpGet(ColorRouteConstants.GetAllColors)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ColorResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<ColorResponse>> GetAllAsync() =>
        _colorService.GetAllAsync();
}
