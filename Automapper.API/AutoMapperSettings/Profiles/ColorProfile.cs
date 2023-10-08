using AutoMapper;
using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;

namespace AutoMapper.API.AutoMapperSettings.Profiles;

public sealed class ColorProfile : Profile
{
	public ColorProfile()
	{
		CreateMap<ColorSaveRequest, Color>();

		CreateMap<Color, ColorResponse>();
	}
}
