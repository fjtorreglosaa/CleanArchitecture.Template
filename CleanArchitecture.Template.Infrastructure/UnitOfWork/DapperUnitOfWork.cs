using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Infrastructure.Abstractions.Dapper;
using CleanArchitecture.Template.Infrastructure.Repositories.EFCore;
using Dapper;
using System.Data;

namespace CleanArchitecture.Template.Infrastructure.UnitOfWork
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;

        public DapperUnitOfWork(IDbConnection dbConnection, IDbTransaction transaction)
        {
            _dbConnection = dbConnection;
            _dbTransaction = transaction;
        }

        public IDapperRentalRepository RentalRepository => new DapperRentalRepository(_dbTransaction, _dbConnection);

        public void BeginTransaction()
        {
            if (_dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.Open();
            }

            _dbTransaction = _dbConnection.BeginTransaction();
        }

        public void Rollback()
        {
            try
            {
                _dbTransaction?.Rollback();
            }
            finally
            {
                _dbConnection?.Close();
            }
        }

        public async Task<IEnumerable<T>> ExecuteDapperAsync<T>(string sql, object parameters = null)
        {
            return await _dbConnection.QueryAsync<T>(sql, parameters, _dbTransaction);
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            try
            {
                _dbTransaction?.Commit();

                return 1;
            }
            catch (Exception ex)
            {
                _dbTransaction?.Rollback();

                throw new ApplicationException("Unexpected exception");
            }
            finally
            {
                _dbConnection?.Close();
            }
        }
    }
}
