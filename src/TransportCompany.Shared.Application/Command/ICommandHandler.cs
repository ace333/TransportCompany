using MediatR;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Shared.Application.Command
{
    public interface ICommandHandler<in TCommand> 
        : IScopedService, IRequestHandler<TCommand> where TCommand : ICommand
    {
    }
}
