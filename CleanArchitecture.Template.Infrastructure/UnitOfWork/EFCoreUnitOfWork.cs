using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Infrastructure.Abstractions.EFCore;

namespace CleanArchitecture.Template.Infrastructure.UnitOfWork
{
    public sealed class EFCoreUnitOfWork : IEFCoreUnitOfWork
    {
        public IRentalVehicleRepository RentalVehicleRepository => throw new NotImplementedException();

        public IRentalRepository RentalRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
