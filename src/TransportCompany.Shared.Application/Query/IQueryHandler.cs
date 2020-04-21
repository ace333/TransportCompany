using MediatR;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Shared.Application.Query
{
    public interface IQueryHandler<in TQuery, TResult> : IScopedService, IRequestHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
        where TResult : class
    {
    }
}
