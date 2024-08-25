using CleanArchitecture.Template.Domain.ValueObjects.Shared;

namespace CleanArchitecture.Template.Domain.ValueObjects.Rentals
{
    public record DetailedPrice
    (
        Price PricePerPeriod,
        Price Maintenance,
        Price Accessories,
        Price TotalPrice
    );
}
