using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using MapperPattern.API.Interfaces.Mappers;

namespace MapperPattern.API.Mappers;

public sealed class ColorMapper : IColorMapper
{
    public Color SaveRequestToDomain(ColorSaveRequest colorSaveRequest) =>
        new()
        {
            Name = colorSaveRequest.Name
        };

    public List<ColorResponse> DomainListToResponseList(List<Color> colorList) =>
        colorList.Select(DomainToResponse).ToList();

    private ColorResponse DomainToResponse(Color color) =>
        new()
        {
            Id = color.Id,
            Name = color.Name
        };
}
