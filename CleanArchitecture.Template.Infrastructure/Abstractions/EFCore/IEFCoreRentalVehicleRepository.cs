using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Infrastructure.Entities;

namespace CleanArchitecture.Template.Infrastructure.Abstractions.EFCore
{
    public interface IEFCoreRentalVehicleRepository : IGenericRepository<RentalVehicle>, IRentalVehicleRepository
    {
    }
}
