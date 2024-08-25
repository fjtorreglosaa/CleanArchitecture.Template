using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.Rentals.Responses.RentalVehicles;
using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Application.Features.RentalVehicles.Queries.GetVehicles
{
    internal sealed class GetVehiclesQueryHandler : IQueryHandler<GetVehiclesQuery, IReadOnlyList<RentalVehicleResponse>>
    {
        public async Task<Result<IReadOnlyList<RentalVehicleResponse>>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
