using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Application.Mapping;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Mapping
{
    public class OrderMappingProfile : MappingProfileBase
    {
        public OrderMappingProfile() : base()
        {
            CreateMap<PaymentAmount, Money>()
                .ForMember(dest => dest.Amount, mbr => mbr.MapFrom(src => src.GrossValue));
        }
    }
}
