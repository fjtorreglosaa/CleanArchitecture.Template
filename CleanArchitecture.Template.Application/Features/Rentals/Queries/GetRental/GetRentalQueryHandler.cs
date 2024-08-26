using CleanArchitecture.Template.Application.Abstractions.Dapper;
using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.Rentals.Responses.Rental;
using CleanArchitecture.Template.Domain.Abstractions;
using Dapper;

namespace CleanArchitecture.Template.Application.Features.Rentals.Queries.GetRental
{
    internal sealed class GetRentalQueryHandler : IQueryHandler<GetRentalQuery, GetRentalResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRentalQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetRentalResponse>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _sqlConnectionFactory.CreateConnecton())
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
                    """;

                var rental = await connection.QueryFirstOrDefaultAsync<GetRentalResponse>(sql, new { request.RentalId });

                return rental;
            }
        }
    }
}
