using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Domain.ValueObjects.Rentals;
using CleanArchitecture.Template.Infrastructure.Contexts;
using CleanArchitecture.Template.Infrastructure.Entities;

namespace CleanArchitecture.Template.Infrastructure.Repositories.EFCore
{
    public sealed class EFCoreRentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        public EFCoreRentalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> IsOverlappingAsync(Domain.DomainModels.RentalVehicles.RentalVehicle vehicle, DateRange duration, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
