using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;

namespace AutoMapper.API.Interfaces;

public interface IColorService
{
    Task<bool> AddAsync(ColorSaveRequest colorSaveRequest);
    Task<List<ColorResponse>> GetAllAsync();
}
