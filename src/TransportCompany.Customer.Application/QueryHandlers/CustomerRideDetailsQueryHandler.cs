using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Mapping;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Domain.Extensions;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerRideDetailsQueryHandler : IQueryHandler<CustomerRideDetailsQuery, CustomerRideDetailsQueryDto>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerRideDetailsQueryHandler(ICustomerUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerRideDetailsQueryDto> Handle(CustomerRideDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.CustomerId);
            Fail.IfNull(customer, request.CustomerId);

            var ride = customer.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);

            return new CustomerRideDetailsQueryDto(
                _mapper.MapRoutes(ride.Routes.OrderFromStart()), 
                ride.Status,
                 _mapper.Map<MoneyDto>(ride.Price), 
                ride.FinishedDate,
                _mapper.Map<DriverDetailsDto>(ride.DriverDetails));
        }
    }
}
