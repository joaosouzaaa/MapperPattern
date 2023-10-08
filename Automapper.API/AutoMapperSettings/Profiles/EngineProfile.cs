using AutoMapper;
using DataTransferObjects.Requests.Engine;
using DataTransferObjects.Responses.Engine;
using Domain.Entities;

namespace AutoMapper.API.AutoMapperSettings.Profiles;

public sealed class EngineProfile : Profile
{
	public EngineProfile()
	{
		CreateMap<EngineSaveRequest, Engine>();

		CreateMap<Engine, EngineResponse>();
	}
}
