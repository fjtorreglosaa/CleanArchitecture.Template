using CleanArchitecture.Template.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Template.Application.Abstractions.Messaging.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>
    {
    }
}
