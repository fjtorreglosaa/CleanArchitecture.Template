namespace CleanArchitecture.Template.Infrastructure.Entities
{
    public sealed class Rental : Entity
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid VehicleId { get; init; }
        public int Status { get; init; }
        public decimal Price { get; init; }
        public string? CurrencyTypeForRental { get; init; }
        public decimal MaintenancePrice { get; set; }
        public string? CurrencyTypeForMaintenance { get; set; }
        public decimal AccessoriesPrice { get; set; }
        public string? CurrencyTypeForAccessories { get; set; }
        public decimal TotalPrice { get; set; }
        public string? CurrencyTypeForTotalPrice { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
