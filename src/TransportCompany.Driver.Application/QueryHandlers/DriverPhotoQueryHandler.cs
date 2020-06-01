using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.Query
{
    public class DriverPhotoQueryHandler : IQueryHandler<DriverPhotoQuery, DriverPhotoQueryDto>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public DriverPhotoQueryHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DriverPhotoQueryDto> Handle(DriverPhotoQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            return new DriverPhotoQueryDto(driver.PersonalInfo.Photo);
        }
    }
}
