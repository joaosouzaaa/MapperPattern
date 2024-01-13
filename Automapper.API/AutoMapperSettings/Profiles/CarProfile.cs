using AutoMapper;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Domain.Entities;

namespace AutoMapper.API.AutoMapperSettings.Profiles;

public sealed class CarProfile : Profile
{
	public CarProfile()
	{
        CreateMap<CarSaveRequest, Car>()
			.ForMember(destination => destination.RegistrationDate, options => options.MapFrom(src => DateTime.UtcNow));

        CreateMap<Car, CarResponse>();
	}
}
