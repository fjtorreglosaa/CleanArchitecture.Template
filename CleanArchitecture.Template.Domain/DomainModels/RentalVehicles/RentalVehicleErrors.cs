using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainModels.RentalVehicles
{
    public static class RentalVehicleErrors
    {
        public static readonly Error NotFound = new(
            "RentalVehicle.NotFound",
            "Vehicule with provided Id does not exist"
        );
    }
}
