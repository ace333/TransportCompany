using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class UploadDriverPhotoCommandHandler : ICommandHandler<UploadDriverPhotoCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public UploadDriverPhotoCommandHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UploadDriverPhotoCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            using (var memoryStream = new MemoryStream())
            {
                request.Photo.OpenReadStream().CopyTo(memoryStream);
                driver.PersonalInfo.Photo = memoryStream.ToArray();
            }

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
