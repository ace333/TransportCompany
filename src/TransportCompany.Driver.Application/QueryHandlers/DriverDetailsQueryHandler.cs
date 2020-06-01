using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.Query
{
    public class DriverDetailsQueryHandler : IQueryHandler<DriverDetailsQuery, DriverDetailsQueryDto>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverDetailsQueryHandler(IDriverUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverDetailsQueryDto> Handle(DriverDetailsQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            return new DriverDetailsQueryDto(driver.PersonalInfo.Name,
                driver.PersonalInfo.Surname,
                driver.PersonalInfo.PhoneNumber,
                driver.PersonalInfo.Email,
                driver.PersonalInfo.Nationality,
                driver.Priority,
                driver.SystemInfo.Grade,
                _mapper.Map<CarDto>(driver.Car),
                _mapper.Map<CompanyDetailsDto>(driver.CompanyDetails),
                _mapper.Map<DriversLicenceDto>(driver.DriversLicense));
        }
    }
}
