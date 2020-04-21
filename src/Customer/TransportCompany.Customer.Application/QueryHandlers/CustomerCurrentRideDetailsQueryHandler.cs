using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerCurrentRideDetailsQueryHandler 
        : IQueryHandler<CustomerCurrentRideDetailsQuery, CustomerCurrentRideDetailsQueryDto>
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;

        public CustomerCurrentRideDetailsQueryHandler(ICustomerUnitOfWork customerUnitOfWork,
            IMapper mapper)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerCurrentRideDetailsQueryDto> Handle(CustomerCurrentRideDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerUnitOfWork.CustomerRepository.GetCustomerWithRides(request.Id);
            Fail.IfNull(customer, request.Id);

            var ride = customer.GetCurrentRide();
            Fail.IfNull(ride, customer, request.Id);

            var addresses = ride.Routes.SelectMany(x => x.GetAddresses)
                .Distinct()
                .Select(x => _mapper.Map<AddressDto>(x));

            var moneyDto = _mapper.Map<MoneyDto>(ride.Price);
            var driverDetailsDto = _mapper.Map<DriverDetailsDto>(ride.DriverDetails);

            return new CustomerCurrentRideDetailsQueryDto(addresses.ToList(), moneyDto, driverDetailsDto);
        }
    }
}
