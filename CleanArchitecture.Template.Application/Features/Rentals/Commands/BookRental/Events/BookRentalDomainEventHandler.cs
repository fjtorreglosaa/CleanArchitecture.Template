using CleanArchitecture.Template.Application.Abstractions.Email;
using CleanArchitecture.Template.Domain.DomainEvents.Rentals;
using CleanArchitecture.Template.Infrastructure.Abstractions.EFCore;
using MediatR;

namespace CleanArchitecture.Template.Application.Features.Rentals.Commands.BookRental.Events
{
    internal sealed class BookRentalDomainEventHandler : INotificationHandler<RentalReserveDomainEvent>
    {
        private readonly IEFCoreUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public BookRentalDomainEventHandler(IEFCoreUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task Handle(RentalReserveDomainEvent notification, CancellationToken cancellationToken)
        {
            var rental = await _unitOfWork.RentalRepository.GetByIdAsync(notification.RentalId, cancellationToken);

            if (rental is null)
            {
                return;
            }

            var user = await _unitOfWork.UserRepository.GetByIdAsync(rental.UserId, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(user.Email, "Rental Booked", "Please confirm your rental");
        }
    }
}
