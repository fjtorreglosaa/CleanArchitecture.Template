using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Domain.Abstractions.UnitOfWork;

namespace CleanArchitecture.Template.Infrastructure.Abstractions.Dapper
{
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        IDapperRentalRepository RentalRepository { get; }

        void BeginTransaction();
        void Rollback();
        Task<IEnumerable<T>> ExecuteDapperAsync<T>(string sql, object parameters = null);
    }
}
