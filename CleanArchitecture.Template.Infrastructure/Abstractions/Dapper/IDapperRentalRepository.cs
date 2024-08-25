using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Infrastructure.Entities;

namespace CleanArchitecture.Template.Infrastructure.Abstractions.Dapper
{
    public interface IDapperRentalRepository : IRentalRepository
    {
        Task<Rental> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
