using MediatR;

namespace TransportCompany.Shared.Application.Query
{
    public interface IQuery<out TResult> 
        : IRequest<TResult> where TResult : class
    {
    }
}
