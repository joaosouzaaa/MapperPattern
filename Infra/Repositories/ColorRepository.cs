using Domain.Entities;
using Infra.DatabaseContexts;
using Infra.Interfaces;
using Infra.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;
public sealed class ColorRepository : BaseRepository<Color>, IColorRepository
{
    public ColorRepository(MapperPatternDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAsync(Color color)
    {
        await _dbContextSet.AddAsync(color);

        return await SaveChangesAsync();
    }

    public async Task<List<Color>> GetAllAsync() =>
        await _dbContextSet.AsNoTracking().ToListAsync();
}
