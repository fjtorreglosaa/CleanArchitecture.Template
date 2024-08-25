using CleanArchitecture.Template.Domain.ValueObjects.Rentals;
using CleanArchitecture.Template.Infrastructure.Abstractions.Dapper;
using CleanArchitecture.Template.Infrastructure.Entities;
using CleanArchitecture.Template.Infrastructure.Repositories.Dapper;
using Dapper;
using System.Data;

namespace CleanArchitecture.Template.Infrastructure.Repositories.EFCore
{
    public sealed class DapperRentalRepository : SqlFactory, IDapperRentalRepository
    {
        public DapperRentalRepository(IDbTransaction dbTransaction, IDbConnection dbConnection) : base(dbTransaction, dbConnection)
        {
        }

        public async Task<Rental> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
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

            var rental = await SqlDbConnection.QueryFirstOrDefaultAsync<Rental>(sql, new { Id = id }, transaction: SqlDbTransaction);

            return rental!;
        }

        public Task<bool> IsOverlappingAsync(Domain.DomainModels.RentalVehicles.RentalVehicle vehicle, DateRange duration, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
