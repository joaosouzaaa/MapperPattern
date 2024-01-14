using Domain.Entities;
using Infra.DatabaseContexts;
using Infra.Interfaces;
using Infra.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Repositories;
public sealed class CarRepository(MapperPatternDatabaseContext dbContext) : BaseRepository<Car>(dbContext), ICarRepository
{
    public async Task<bool> AddAsync(Car car)
    {
        await DbContextSet.AddAsync(car);

        return await SaveChangesAsync();
    }

    public async Task<Car?> GetByIdAsync(int id, Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null)
    {
        var query = (IQueryable<Car>)DbContextSet;

        if (includes is not null)
            query = includes(query);

        return await query.AsNoTracking().FirstOrDefaultAsync<Car>(c => c.Id == id);
    }

    public async Task<List<Car>> GetAllAsync(Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null)
    {
        var query = (IQueryable<Car>)DbContextSet;

        if (includes is not null)
            query = includes(query);

        return await query.AsNoTracking().ToListAsync();
    }
}
