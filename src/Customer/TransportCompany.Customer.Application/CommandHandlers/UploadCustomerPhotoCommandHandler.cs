using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class UploadCustomerPhotoCommandHandler : ICommandHandler<UploadCustomerPhotoCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public UploadCustomerPhotoCommandHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UploadCustomerPhotoCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.FindAsync(request.Id);
            Fail.IfNull(customer, request.Id);

            using (var memoryStream = new MemoryStream())
            {
                request.Photo.OpenReadStream().CopyTo(memoryStream);
                customer.PersonalInfo.Photo = memoryStream.ToArray();
            }

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
