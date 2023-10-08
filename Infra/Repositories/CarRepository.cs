using Domain.Entities;
using Infra.DatabaseContexts;
using Infra.Interfaces;
using Infra.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Repositories;
public sealed class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(MapperPatternDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAsync(Car car)
    {
        await _dbContextSet.AddAsync(car);

        return await SaveChangesAsync();
    }

    public async Task<Car> GetByIdAsync(int id, Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null)
    {
        var query = (IQueryable<Car>)_dbContextSet;

        if (includes is not null)
            query = includes(query);

        return await _dbContextSet.AsNoTracking().FirstOrDefaultAsync<Car>(c => c.CarId == id);
    }

    public async Task<List<Car>> GetAllAsync(Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null)
    {
        var query = (IQueryable<Car>)_dbContextSet;

        if (includes is not null)
            query = includes(query);

        return await query.AsNoTracking().ToListAsync();
    }
}
