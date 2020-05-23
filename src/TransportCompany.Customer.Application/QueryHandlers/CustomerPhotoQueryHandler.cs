using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerPhotoQueryHandler: IQueryHandler<CustomerPhotoQuery, CustomerPhotoQueryDto>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CustomerPhotoQueryHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerPhotoQueryDto> Handle(CustomerPhotoQuery request, CancellationToken cancellationToken)
        {
            var photo = await _unitOfWork.CustomerRepository.GetCustomerPhotoById(request.Id);
            return new CustomerPhotoQueryDto(photo);
        }
    }
}
