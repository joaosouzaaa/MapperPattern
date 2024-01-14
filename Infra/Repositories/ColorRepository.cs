using Domain.Entities;
using Infra.DatabaseContexts;
using Infra.Interfaces;
using Infra.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;
public sealed class ColorRepository(MapperPatternDatabaseContext dbContext) : BaseRepository<Color>(dbContext), IColorRepository
{
    public async Task<bool> AddAsync(Color color)
    {
        await DbContextSet.AddAsync(color);

        return await SaveChangesAsync();
    }

    public Task<List<Color>> GetAllAsync() =>
        DbContextSet.AsNoTracking().ToListAsync();

    public Task<Color?> GetByIdAsync(int id) =>
        DbContextSet.FirstOrDefaultAsync(c => c.Id == id);
}
