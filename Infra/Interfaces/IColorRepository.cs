using Domain.Entities;

namespace Infra.Interfaces;

public interface IColorRepository
{
    Task<bool> AddAsync(Color color);
    Task<List<Color>> GetAllAsync();
}