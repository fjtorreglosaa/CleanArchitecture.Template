namespace CleanArchitecture.Template.Infrastructure.Entities
{
    public sealed class RentalVehicle : Entity
    {
        public Guid Id { get; init; }
        public string? Model { get; init; }
        public string? Serie { get; init; }
        public decimal Price { get; init; }
        public string? CurrentType { get; init; }
        public string? Country { get; init; }
        public string? Department { get; init; }
        public string? Province { get; init; }
        public string? Street { get; init; }
    }
}
