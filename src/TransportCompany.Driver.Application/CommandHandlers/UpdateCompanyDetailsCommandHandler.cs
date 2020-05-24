using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class UpdateCompanyDetailsCommandHandler : ICommandHandler<UpdateCompanyDetailsCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public UpdateCompanyDetailsCommandHandler(IDriverUnitOfWork unitOfWork, IDriverService driverService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _driverService = driverService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyDetailsCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            _driverService.UpdateDriversCompanyDetails(driver, 
                request.CompanyName, 
                request.OwnerName,
                _mapper.Map<BankDetails>(request.BankDetails),
                _mapper.Map<Address>(request.Address),
                request.TaxIdentificationNumber,
                request.NationalEconomyRegisterNumber);

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
