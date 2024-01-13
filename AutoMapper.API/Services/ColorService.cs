using AutoMapper.API.Extensions;
using AutoMapper.API.Interfaces;
using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using Infra.Interfaces;

namespace AutoMapper.API.Services;

public sealed class ColorService(IColorRepository colorRepository) : IColorService, IColorFacadeService
{
    private readonly IColorRepository _colorRepository = colorRepository;

    public Task<bool> AddAsync(ColorSaveRequest colorSaveRequest)
    {
        var color = colorSaveRequest.MapTo<ColorSaveRequest, Color>();

        return _colorRepository.AddAsync(color);
    }

    public async Task<List<ColorResponse>> GetAllAsync()
    {
        var colorList = await _colorRepository.GetAllAsync();

        return colorList.MapTo<List<Color>, List<ColorResponse>>();
    }

    public Task<Color> GetByIdReturnsDomainObjectAsync(int id) =>
        _colorRepository.GetByIdAsync(id);
}
