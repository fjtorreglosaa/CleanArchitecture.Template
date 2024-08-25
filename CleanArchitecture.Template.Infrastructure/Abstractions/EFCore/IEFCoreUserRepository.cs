using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Infrastructure.Entities;

namespace CleanArchitecture.Template.Infrastructure.Abstractions.EFCore
{
    public interface IEFCoreUserRepository : IGenericRepository<User>, IUserRepository
    {
    }
}
