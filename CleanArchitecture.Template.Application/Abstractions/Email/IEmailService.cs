namespace CleanArchitecture.Template.Application.Abstractions.Email
{
    internal interface IEmailService
    {
        Task SendAsync(Domain.ValueObjects.Users.Email recipient, string subject, string body);
    }
}
