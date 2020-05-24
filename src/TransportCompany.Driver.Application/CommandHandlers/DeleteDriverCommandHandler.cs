using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class DeleteDriverCommandHandler : ICommandHandler<DeleteDriverCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public DeleteDriverCommandHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            _unitOfWork.Delete(driver);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
