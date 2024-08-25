using CleanArchitecture.Template.Application.Abstractions.Clock;
using CleanArchitecture.Template.Application.Abstractions.Messaging.Commands;
using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Domain.DomainModels.Rentals;
using CleanArchitecture.Template.Domain.DomainModels.RentalVehicles;
using CleanArchitecture.Template.Domain.DomainModels.Users;
using CleanArchitecture.Template.Domain.DomainServices.Shared;
using CleanArchitecture.Template.Domain.ValueObjects.Rentals;
using CleanArchitecture.Template.Infrastructure.Abstractions.EFCore;

namespace CleanArchitecture.Template.Application.Features.Rentals.Commands.BookRental
{
    internal sealed class BookRentalCommandHandler : ICommandHandler<BookRentalCommand, Guid>
    {
        private readonly IEFCoreUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly PriceDomainService _priceDomainService;

        public BookRentalCommandHandler(IEFCoreUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, PriceDomainService priceDomainService)
        {
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _priceDomainService = priceDomainService;
        }

        public async Task<Result<Guid>> Handle(BookRentalCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.userId, cancellationToken);

            if (user is null)
            {
                return Result.Failure<Guid>(UserErros.NotFound);
            }

            var vehicle = await _unitOfWork.RentalVehicleRepository.GetByIdAsync(request.rentalVehicleId, cancellationToken);

            if (vehicle is null)
            {
                return Result.Failure<Guid>(RentalVehicleErrors.NotFound);
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);
            
            var overlapping = await _unitOfWork.RentalRepository.IsOverlappingAsync(vehicle, duration, cancellationToken);

            if (overlapping)
            {
                return Result.Failure<Guid>(RentalErrors.Overlap);
            }

            var rental = Rental.Create
            (
                user.Id,
                vehicle,
                duration,
                _dateTimeProvider.CurrentTime,
                _priceDomainService
            );

            await _unitOfWork.RentalRepository.AddAsync(rental);
            await _unitOfWork.SaveChanges(cancellationToken);

            return rental.Id;
        }
    }
}
