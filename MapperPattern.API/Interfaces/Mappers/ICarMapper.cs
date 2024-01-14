using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Domain.Entities;

namespace MapperPattern.API.Interfaces.Mappers;

public interface ICarMapper
{
    Car SaveRequestToDomain(CarSaveRequest carSaveRequest);
    CarResponse DomainToResponse(Car car);
    List<CarResponse> DomainListToResponseList(List<Car> carList);
    CarWithRelationshipsResponse DomainToWithRelationshipsResponse(Car car);
    List<CarWithRelationshipsResponse> DomainListToWithRelationshipsResponseList(List<Car> carList);
}
