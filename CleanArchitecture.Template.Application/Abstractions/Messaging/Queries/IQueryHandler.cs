using CleanArchitecture.Template.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Template.Application.Abstractions.Messaging.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}
