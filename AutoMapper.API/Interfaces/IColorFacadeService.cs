using Domain.Entities;

namespace AutoMapper.API.Interfaces;

public interface IColorFacadeService
{
    Task<Color> GetByIdReturnsDomainObjectAsync(int id);
}
