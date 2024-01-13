using DataTransferObjects.Requests.Color;
using DataTransferObjects.Responses.Color;
using Domain.Entities;

namespace MapperPattern.API.Interfaces.Mappers;

public interface IColorMapper
{
    Color SaveRequestToDomain(ColorSaveRequest colorSaveRequest);
    List<ColorResponse> DomainListToResponseList(List<Color> colorList);
}
