using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;
using TransportCompany.Shared.Infrastructure.Extensions;

namespace TransportCompany.Driver.Application.QueryHandlers
{
    public class DriversQueryHandler : IQueryHandler<DriversQuery, PaginatedList<DriversQueryDto>>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public DriversQueryHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PaginatedList<DriversQueryDto>> Handle(DriversQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.DriverRepository.GetAll()
                .Select(x => new DriversQueryDto
                {
                    Id = x.Id,
                    Email = x.PersonalInfo.Email,
                    Name = x.PersonalInfo.Name,
                    Surname = x.PersonalInfo.Surname,
                    Nationality = x.PersonalInfo.Nationality,
                    PhoneNumber = x.PersonalInfo.PhoneNumber,
                    Priority = x.Priority,
                    CarModel = x.Car.Model,
                    CarRegistrationPlateNumber = x.Car.RegistrationPlateNumber,
                    CompanyName = x.CompanyDetails.CompanyName,
                    TaxIdentificationNumber = x.CompanyDetails.TaxIdentificationNumber
                })
                .AsPaginatedList(request.GetPagingElements());
        }
    }
}
