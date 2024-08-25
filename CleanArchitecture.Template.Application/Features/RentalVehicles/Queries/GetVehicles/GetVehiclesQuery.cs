using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.Rentals.Responses.RentalVehicles;

namespace CleanArchitecture.Template.Application.Features.RentalVehicles.Queries.GetVehicles
{
    public sealed record GetVehiclesQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<RentalVehicleResponse>>;
}
