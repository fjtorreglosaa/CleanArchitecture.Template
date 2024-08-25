using CleanArchitecture.Template.Domain.Abstractions.Repositories;

namespace CleanArchitecture.Template.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRentalVehicleRepository RentalVehicleRepository { get; }
        IRentalRepository RentalRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
