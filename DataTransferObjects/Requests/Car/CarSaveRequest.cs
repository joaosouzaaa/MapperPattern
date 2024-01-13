using DataTransferObjects.Enums;
using DataTransferObjects.Requests.CarFeature;
using DataTransferObjects.Requests.Engine;

namespace DataTransferObjects.Requests.Car;
public sealed record CarSaveRequest(string Model, 
                                    int Year,
                                    decimal Price,
                                    EFuelTypeRequest FuelType,
                                    bool HasNavigationSystem,
                                    EngineSaveRequest Engine,
                                    List<CarFeatureSaveRequest> CarFeatures,
                                    List<int> ColorIds);
