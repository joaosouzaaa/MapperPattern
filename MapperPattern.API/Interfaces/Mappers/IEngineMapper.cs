using DataTransferObjects.Requests.Engine;
using DataTransferObjects.Responses.Engine;
using Domain.Entities;

namespace MapperPattern.API.Interfaces.Mappers;

public interface IEngineMapper
{
    Engine SaveRequestToDomain(EngineSaveRequest engineSaveRequest);
    EngineResponse DomainToResponse(Engine engine);
}
