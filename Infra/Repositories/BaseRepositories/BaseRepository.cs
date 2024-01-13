using Infra.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.BaseRepositories;
public abstract class BaseRepository<TEntity>(MapperPatternDatabaseContext dbContext) : IDisposable
    where TEntity : class
{
    private readonly MapperPatternDatabaseContext _dbContext = dbContext;
    protected DbSet<TEntity> DbContextSet => _dbContext.Set<TEntity>();

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _dbContext.Dispose();
    }

    protected async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;
}
