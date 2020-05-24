using TransportCompany.Shared.Application.Mapping;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.Mapping
{
    public class CustomerMappingProfile: MappingProfileBase
    {
        public CustomerMappingProfile() : base()
        {
            CreateMap<Domain.Entities.Customer, CustomerDetails>()
                .ForMember(dest => dest.Name, mbr => mbr.MapFrom(src => src.PersonalInfo.Name))
                .ForMember(dest => dest.Surname, mbr => mbr.MapFrom(src => src.PersonalInfo.Surname))
                .ForMember(dest => dest.PhoneNumber, mbr => mbr.MapFrom(src => src.PersonalInfo.PhoneNumber))
                .ForMember(dest => dest.Email, mbr => mbr.MapFrom(src => src.PersonalInfo.Email))
                .ForMember(dest => dest.Grade, mbr => mbr.MapFrom(src => src.SystemInfo.Grade));
        }
    }
}
