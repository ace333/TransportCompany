using AutoMapper;
using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Mapping
{
    public class OrderMappingProfile: Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<PaymentAmount, Money>()
                .ForMember(dest => dest.Amount, mbr => mbr.MapFrom(src => src.GrossValue));
        }
    }
}
