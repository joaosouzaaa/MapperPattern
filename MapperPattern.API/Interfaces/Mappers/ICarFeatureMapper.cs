using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.CarFeature;
using Domain.Entities;

namespace MapperPattern.API.Interfaces.Mappers;

public interface ICarFeatureMapper
{
    List<CarFeature> SaveRequestListToDomainList(List<CarFeatureSaveRequest> carFeatureSaveRequestList);
    List<CarFeatureResponse> DomainListToResponseList(List<CarFeature> carFeatureList);
}
