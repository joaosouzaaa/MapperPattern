using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;

namespace MapperPattern.API.Interfaces.Services;

public interface IColorService
{
    Task<bool> AddAsync(ColorSaveRequest colorSaveRequest);
    Task<List<ColorResponse>> GetAllAsync();
}
