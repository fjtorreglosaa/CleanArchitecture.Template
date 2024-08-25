using CleanArchitecture.Template.Infrastructure.Abstractions.EFCore;
using CleanArchitecture.Template.Infrastructure.Contexts;
using CleanArchitecture.Template.Infrastructure.Entities;

namespace CleanArchitecture.Template.Infrastructure.Repositories.EFCore
{
    public sealed class EFCoreRentalVehicleRepository : GenericRepository<RentalVehicle>, IEFCoreRentalVehicleRepository
    {
        public EFCoreRentalVehicleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
