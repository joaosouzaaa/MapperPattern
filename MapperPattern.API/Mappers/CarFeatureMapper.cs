using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.CarFeature;
using Domain.Entities;
using MapperPattern.API.Interfaces.Mappers;

namespace MapperPattern.API.Mappers;

public sealed class CarFeatureMapper : ICarFeatureMapper
{
    public List<CarFeature> SaveRequestListToDomainList(List<CarFeatureSaveRequest> carFeatureSaveRequestList) =>
        carFeatureSaveRequestList.Select(SaveRequestToDomain).ToList();

    public List<CarFeatureResponse> DomainListToResponseList(List<CarFeature> carFeatureList) =>
        carFeatureList.Select(DomainToResponse).ToList();
    
    private CarFeature SaveRequestToDomain(CarFeatureSaveRequest carFeatureSaveRequest) =>
        new()
        {
            IsAvailable = carFeatureSaveRequest.IsAvailable,
            Name = carFeatureSaveRequest.Name
        };

    private CarFeatureResponse DomainToResponse(CarFeature carFeature) =>
        new()
        {
            IsAvailable = carFeature.IsAvailable,
            Id = carFeature.Id,
            Name = carFeature.Name,
        };
}
