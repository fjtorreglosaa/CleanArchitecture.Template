using System.Data;

namespace CleanArchitecture.Template.Infrastructure.Repositories.Dapper
{
    public abstract class SqlFactory
    {
        protected IDbTransaction SqlDbTransaction;
        protected IDbConnection SqlDbConnection;

        public SqlFactory(IDbTransaction dbTransaction, IDbConnection dbConnection)
        {
            SqlDbTransaction = dbTransaction;
            SqlDbConnection = dbConnection;
        }
    }
}
