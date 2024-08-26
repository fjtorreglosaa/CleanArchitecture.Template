using System.Data;

namespace CleanArchitecture.Template.Application.Abstractions.Dapper
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnecton();
    }
}
