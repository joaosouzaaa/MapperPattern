using AutoMapper.API.AutoMapperSettings;

namespace AutoMapper.API.Extensions;

public static class AutoMapperExtension
{
    public static TDestination MapTo<TSource, TDestination>(this TSource source)
            where TSource : class
            where TDestination : class
            =>
            AutoMapperFactory.Mapper.Map<TSource, TDestination>(source);
}
