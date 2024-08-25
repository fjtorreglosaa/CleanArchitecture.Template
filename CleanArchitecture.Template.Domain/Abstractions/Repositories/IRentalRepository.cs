using CleanArchitecture.Template.Domain.DomainModels.Rentals;
using CleanArchitecture.Template.Domain.DomainModels.RentalVehicles;
using CleanArchitecture.Template.Domain.ValueObjects.Rentals;

namespace CleanArchitecture.Template.Domain.Abstractions.Repositories
{
    public interface IRentalRepository
    {
        Task<bool> IsOverlappingAsync(RentalVehicle vehicle, DateRange duration, CancellationToken cancellationToken);
    }
}
