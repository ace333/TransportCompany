using AutoMapper;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Application.Mapping
{
    public class DriverMappingProfile: Profile
    {
        public DriverMappingProfile()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<MoneyDto, Money>();
            CreateMap<CustomerDetailsDto, CustomerDetails>();

            CreateMap<Domain.Entities.Driver, DriverDetails>()
                .ForMember(dest => dest.Name, mbr => mbr.MapFrom(src => src.PersonalInfo.Name))
                .ForMember(dest => dest.Grade, mbr => mbr.MapFrom(src => src.SystemInfo.Grade))
                .ForMember(dest => dest.Photo, mbr => mbr.MapFrom(src => src.PersonalInfo.Photo))
                .ForMember(dest => dest.CarModel, mbr => mbr.MapFrom(src => src.Car.Model))
                .ForMember(dest => dest.CarRegistrationPlateNumber, mbr => mbr.MapFrom(src => src.Car.RegistrationPlateNumber));
        }
    }
}
