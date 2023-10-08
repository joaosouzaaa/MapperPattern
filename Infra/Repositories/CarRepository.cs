using Domain.Entities;
using Infra.DatabaseContexts;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Repositories;
public sealed class CarRepository : ICarRepository, IDisposable
{
    private readonly MapperPatternDatabaseContext _dbContext;
    private DbSet<Car> _dbContextSet => _dbContext.Set<Car>();

    public CarRepository(MapperPatternDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Car car)
    {
        await _dbContextSet.AddAsync(car);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Car car)
    {
        _dbContext.Entry<Car>(car).State = EntityState.Modified;

        return await SaveChangesAsync();
    }

    public async Task<Car> GetByIdAsync(int id, Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null)
    {
        var query = (IQueryable<Car>)_dbContextSet;

        if (includes is not null)
            query = includes(query);

        return await _dbContextSet.FirstOrDefaultAsync<Car>(c => c.CarId == id);
    }

    public async Task<List<Car>> GetAllAsync(Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = null)
    {
        var query = (IQueryable<Car>)_dbContextSet;

        if (includes is not null)
            query = includes(query);

        return await query.AsNoTracking().ToListAsync();
    }

    public void Dispose() =>
        _dbContext.Dispose();

    private async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;
}
