using AutoMapper;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Mapping
{
    public class CustomerMappingProfile: Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<DriverDetails, DriverDetailsDto>();
        }
    }
}
