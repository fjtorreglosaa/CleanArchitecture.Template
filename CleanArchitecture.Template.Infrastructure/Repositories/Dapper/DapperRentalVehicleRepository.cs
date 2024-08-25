using CleanArchitecture.Template.Infrastructure.Entities;
using CleanArchitecture.Template.Infrastructure.Repositories.Dapper;
using Dapper;
using System.Data;

namespace CleanArchitecture.Template.Infrastructure.Repositories.EFCore
{
    public sealed class DapperRentalVehicleRepository : SqlFactory
    {
        public DapperRentalVehicleRepository(IDbTransaction dbTransaction, IDbConnection dbConnection) : base(dbTransaction, dbConnection)
        {
        }

        public async Task<IEnumerable<RentalVehicle>> GetRentalByIdAsync(CancellationToken cancellationToken = default)
        {
            var sql = """
                        SELECT 
                            Id,
                            VehicleId,
                            UserId,
                            Status,
                            Price,
                            CurrencyTypeForRental,
                            MaintenancePrice,
                            CurrencyTypeForMaintenance,
                            AccessoriesPrice,
                            CurrencyTypeForAccessories,
                            TotalPrice,
                            CurrencyTypeForTotalPrice,
                            StartDate,
                            EndDate,
                            CreatedDate
                        FROM Rentals 
                        WHERE Id = @Id
                    """
            ;

            var vehicles = await SqlDbConnection.QueryAsync<RentalVehicle>(sql, transaction: SqlDbTransaction);

            return vehicles!;
        }
    }
}
