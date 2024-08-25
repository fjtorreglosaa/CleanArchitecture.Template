using CleanArchitecture.Template.Application.Features.Rentals.Responses.Shared;

namespace CleanArchitecture.Template.Application.Features.Rentals.Responses.RentalVehicles
{
    public sealed class RentalVehicleResponse
    {
        public Guid Id { get; init; }
        public string? Model { get; init; }
        public string? Serie { get; init; }
        public decimal Price { get; init; }
        public string? CurrentType { get; init; }
        public AddressResponse? Address { get; set; }
    }
}
