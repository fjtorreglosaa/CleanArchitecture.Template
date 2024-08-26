using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.RentalVehicles.Responses;

namespace CleanArchitecture.Template.Application.Features.RentalVehicles.Queries.GetRentalVehicles
{
    public record GetRentalVehiclesQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<RentalVehicleResponse>>;
}
