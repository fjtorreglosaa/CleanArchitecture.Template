using CleanArchitecture.Template.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Template.Application.Abstractions.Messaging.Commands
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }
}
