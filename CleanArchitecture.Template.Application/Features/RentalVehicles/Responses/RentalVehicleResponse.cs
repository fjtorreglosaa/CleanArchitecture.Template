namespace CleanArchitecture.Template.Application.Features.RentalVehicles.Responses
{
    public sealed class RentalVehicleResponse
    {
        public Guid Id { get; init; }
        public string? Model { get; init; }
        public string? Series { get; init; }
        public decimal Price { get; init; }
        public string? CurrencyType { get; init; }
        public AddressResponse? Address { get; set; }
    }
}
