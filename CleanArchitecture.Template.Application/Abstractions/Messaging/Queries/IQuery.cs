using CleanArchitecture.Template.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Template.Application.Abstractions.Messaging.Queries
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
