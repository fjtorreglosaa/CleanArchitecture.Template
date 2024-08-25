using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Domain.Abstractions.UnitOfWork;

namespace CleanArchitecture.Template.Infrastructure.Abstractions.EFCore
{
    public interface IEFCoreUnitOfWork : IUnitOfWork
    {
        IEFCoreRentalVehicleRepository RentalVehicleRepository { get; }
        IEFCoreRentalRepository RentalRepository { get; }
        IEFCoreUserRepository UserRepository { get; }
    }
}
