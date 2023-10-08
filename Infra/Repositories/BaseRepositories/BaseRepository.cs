using Infra.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.BaseRepositories;
public abstract class BaseRepository<TEntity> : IDisposable
    where TEntity : class
{
    protected readonly MapperPatternDatabaseContext _dbContext;
    protected DbSet<TEntity> _dbContextSet => _dbContext.Set<TEntity>();

    public BaseRepository(MapperPatternDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;

    public void Dispose() =>
        _dbContext.Dispose();
}
