using DataTransferObjects.Enums;
using DataTransferObjects.Requests.Car;
using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Responses.Car;
using DataTransferObjects.Responses.CarFeature;
using DataTransferObjects.Responses.Color;
using Domain.Entities;
using Domain.Enums;

namespace UnitTests.TestBuilders;
public sealed class CarBuilder
{
    private readonly bool _hasNavigationSystem = true;
    private readonly string _model = "test";
    private readonly decimal _price = 123.98m;
    private readonly DateTime _registrationDate = DateTime.UtcNow;
    private readonly int _year = 123;
    private List<CarFeature> _carFeatureList = [];
    private List<Color> _colorList = [];
    private List<CarFeatureSaveRequest> _carFeatureSaveRequestList = [];
    private List<int> _colorIdList = [];
    private readonly List<CarFeatureResponse> _carFeatureResponseList = [];
    private readonly List<ColorResponse> _colorResponseList = [];

    public static CarBuilder NewObject() =>
        new();

    public Car DomainBuild() =>
        new()
        {
            CarFeatures = _carFeatureList,
            Colors = _colorList,
            Engine = EngineBuilder.NewObject().DomainBuild(),
            FuelType = EFuelType.Gasoline,
            Id = 123,
            HasNavigationSystem = _hasNavigationSystem,
            Model = _model,
            Price = _price,
            RegistrationDate = _registrationDate,
            Year = _year
        };

    public CarSaveRequest SaveRequestBuild() =>
        new(_model,
            _year,
            _price,
            EFuelTypeRequest.Diesel,
            _hasNavigationSystem,
            EngineBuilder.NewObject().SaveRequestBuild(),
            _carFeatureSaveRequestList,
            _colorIdList);

    public CarResponse ResponseBuild() =>
        new()
        {
            FuelType = 1,
            HasNavigationSystem = _hasNavigationSystem,
            Id = 12,
            Model = _model,
            Price = _price,
            RegistrationDate = _registrationDate,
            Year = _year
        };

    public CarWithRelationshipsResponse WithRelationshipsResponseBuild() =>
        new()
        {
            CarFeatures = _carFeatureResponseList,
            Colors = _colorResponseList,
            Engine = EngineBuilder.NewObject().ResponseBuild(),
            FuelType = 1,
            HasNavigationSystem = _hasNavigationSystem,
            Id = 12,
            Model = _model,
            Price = _price,
            RegistrationDate = _registrationDate,
            Year = _year
        };

    public CarBuilder WithCarFeatureSaveRequestList(List<CarFeatureSaveRequest> carFeatureSaveRequestList)
    {
        _carFeatureSaveRequestList = carFeatureSaveRequestList;

        return this;
    }

    public CarBuilder WithCarFeatureList(List<CarFeature> carFeatureList)
    {
        _carFeatureList = carFeatureList;

        return this;
    }

    public CarBuilder WithColorList(List<Color> colorList)
    {
        _colorList = colorList;

        return this;
    }

    public CarBuilder WithColorIdList(List<int> colorIdList)
    {
        _colorIdList = colorIdList;

        return this;
    }
}
