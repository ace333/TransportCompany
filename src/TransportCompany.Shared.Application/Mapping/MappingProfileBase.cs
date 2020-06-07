using AutoMapper;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Shared.Application.Mapping
{
    public abstract class MappingProfileBase : Profile
    {
        protected MappingProfileBase()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            CreateMap<MoneyDto, Money>();
            CreateMap<Money, MoneyDto>();

            CreateMap<InvoiceDto, Invoice>();
            CreateMap<Invoice, InvoiceDto>();

            CreateMap<CustomerDetails, CustomerDetailsDto>();
            CreateMap<DriverDetails, DriverDetailsDto>();
        }
    }
}
