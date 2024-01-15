using Domain.Entities;

namespace MapperPattern.API.Interfaces.Services;

public interface IColorFacadeService
{
    Task<Color?> GetByIdReturnsDomainObjectAsync(int id);
}
