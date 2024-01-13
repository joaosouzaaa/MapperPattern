using DataTransferObjects.Enums;

namespace DataTransferObjects.Requests.Engine;
public sealed record EngineSaveRequest(EEngineTypeRequest Type,
                                       double Horsepower,
                                       string Description);
