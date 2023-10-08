using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Interfaces;
public interface ICarRepository
{
    Task<bool> AddAsync(Car car);
    Task<bool> UpdateAsync(Car car);
    Task<Car> GetByIdAsync(int id, Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null);
    Task<List<Car>> GetAllAsync(Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null);
}
