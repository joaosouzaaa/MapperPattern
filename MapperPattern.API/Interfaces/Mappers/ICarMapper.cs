using DataTransferObjects.Requests.Car;
using DataTransferObjects.Responses.Car;
using Domain.Entities;

namespace MapperPattern.API.Interfaces.Mappers;

public interface ICarMapper
{
    Car SaveRequestToDomain(CarSaveRequest carSaveRequest);
    List<CarResponse> DomainListToResponseList(List<Car> carList);
}
