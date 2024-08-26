using CleanArchitecture.Template.Application.Abstractions.Dapper;
using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.RentalVehicles.Responses;
using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Domain.Enums.Rentals;
using Dapper;

namespace CleanArchitecture.Template.Application.Features.RentalVehicles.Queries.GetRentalVehicles
{
    internal sealed class GetRentalVehiclesQueryHandler : IQueryHandler<GetRentalVehiclesQuery, IReadOnlyList<RentalVehicleResponse>>
    {
        private static readonly int[] ActiveRentalStatuses =
        {
            (int)RentalStatus.Reserved,
            (int)RentalStatus.Confirmed,
            (int)RentalStatus.Completed
        };

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRentalVehiclesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<RentalVehicleResponse>>> Handle(GetRentalVehiclesQuery request, CancellationToken cancellationToken)
        {
            if (request.StartDate > request.EndDate)
            {
                return new List<RentalVehicleResponse>();
            }

            using (var connection = _sqlConnectionFactory.CreateConnecton())
            {
                const string sql = """
                    SELECT
                        a.Id,
                        a.Model,
                        a.Series,
                        a.Price,
                        a.CurrencyType,
                        a.Country,
                        a.Department,
                        a.Province,
                        a.Street
                    FROM RentalVehicles AS a
                    WHERE NOT EXISTS
                    (
                        SELECT 1
                        FROM Rentals AS b
                        WHERE
                            b.RentalVehicleId = a.Id AND
                            b.Start <= @EndDate AND
                            b.End <= @StartDate AND
                            b.Status = ANY(@ActiveRentalStatuses)
                    )
                """;

                var vehicles = await connection
                    .QueryAsync<RentalVehicleResponse, AddressResponse, RentalVehicleResponse>
                    (
                        sql,
                        (vehicle, address) => {
                            vehicle.Address = address;
                            return vehicle;
                        },
                        new
                        {
                            request.StartDate,
                            request.EndDate,
                            ActiveRentalStatuses
                        },
                        splitOn: "Country"
                    );

                return vehicles.ToList();
            }
        }
    }
}
