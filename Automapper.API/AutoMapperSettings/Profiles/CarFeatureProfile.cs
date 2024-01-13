using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.CarFeature;
using Domain.Entities;

namespace AutoMapper.API.AutoMapperSettings.Profiles;

public sealed class CarFeatureProfile : Profile
{
	public CarFeatureProfile()
	{
		CreateMap<CarFeatureSaveRequest, CarFeature>();

		CreateMap<CarFeature, CarFeatureResponse>();
	}
}
