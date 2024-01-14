using Microsoft.EntityFrameworkCore.Query;
using Moq;

namespace UnitTests.TestBuilders.TestUtils;
public static class TestBuilderUtil
{
    public static Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildQueryableIncludeFunc<TEntity>()
        where TEntity : class =>
        It.IsAny<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();
}
