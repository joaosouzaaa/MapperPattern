using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using Infra.Interfaces;
using MapperPattern.API.Interfaces.Mappers;
using MapperPattern.API.Interfaces.Services;

namespace MapperPattern.API.Services;

public sealed class ColorService(IColorRepository colorRepository, IColorMapper colorMapper) : IColorService, IColorFacadeService
{
    private readonly IColorRepository _colorRepository = colorRepository;
    private readonly IColorMapper _colorMapper = colorMapper;

    public Task<bool> AddAsync(ColorSaveRequest colorSaveRequest)
    {
        var color = _colorMapper.SaveRequestToDomain(colorSaveRequest);

        return _colorRepository.AddAsync(color);
    }

    public async Task<List<ColorResponse>> GetAllAsync()
    {
        var colorList = await _colorRepository.GetAllAsync();

        return _colorMapper.DomainListToResponseList(colorList);
    }

    public Task<Color?> GetByIdReturnsDomainObjectAsync(int id) =>
        _colorRepository.GetByIdAsync(id);
}
