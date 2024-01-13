using DataTransferObjects.Requests.Engine;
using DataTransferObjects.Responses.Engine;
using Domain.Entities;
using Domain.Enums;
using MapperPattern.API.Interfaces.Mappers;

namespace MapperPattern.API.Mappers;

public sealed class EngineMapper : IEngineMapper
{
    public Engine SaveRequestToDomain(EngineSaveRequest engineSaveRequest) =>
        new()
        {
            Description = engineSaveRequest.Description,
            Horsepower = engineSaveRequest.Horsepower,
            Type = (EEngineType)engineSaveRequest.Type
        };

    public EngineResponse DomainToResponse(Engine engine) =>
        new()
        {
            Description = engine.Description,
            Horsepower = engine.Horsepower,
            Id = engine.Id,
            Type = (ushort)engine.Type
        };
}
