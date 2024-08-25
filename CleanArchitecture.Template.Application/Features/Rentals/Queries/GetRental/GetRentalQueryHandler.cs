using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.Rentals.Responses.Rental;
using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Infrastructure.Abstractions.Dapper;

namespace CleanArchitecture.Template.Application.Features.Rentals.Queries.GetRental
{
    internal sealed class GetRentalQueryHandler : IQueryHandler<GetRentalQuery, GetRentalResponse>
    {
        private readonly IDapperUnitOfWork _unitOfWork;

        public async Task<Result<GetRentalResponse>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
        {
            var rental = await _unitOfWork.RentalRepository.GetByIdAsync(request.RentalId, cancellationToken);

            if (rental == null)
            {

            }

            return null;
        }
    }
}
