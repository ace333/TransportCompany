using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Application.Mapping;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Application.Mapping
{
    public class DriverMappingProfile: MappingProfileBase
    {
        public DriverMappingProfile() : base()
        {
            CreateMap<BankDetailsDto, BankDetails>();
            CreateMap<BankDetails, BankDetailsDto>();

            CreateMap<CarDto, Car>();
            CreateMap<Car, CarDto>();

            CreateMap<CompanyDetailsDto, CompanyDetails>();
            CreateMap<CompanyDetails, CompanyDetailsDto>();

            CreateMap<DriversLicenceDto, DriversLicense>();
            CreateMap<DriversLicense, DriversLicenceDto>();

            CreateMap<Domain.Entities.Driver, DriverDetails>()
                .ForMember(dest => dest.Name, mbr => mbr.MapFrom(src => src.PersonalInfo.Name))
                .ForMember(dest => dest.Grade, mbr => mbr.MapFrom(src => src.SystemInfo.Grade))
                .ForMember(dest => dest.Photo, mbr => mbr.MapFrom(src => src.PersonalInfo.Photo))
                .ForMember(dest => dest.CarModel, mbr => mbr.MapFrom(src => src.Car.Model))
                .ForMember(dest => dest.CarRegistrationPlateNumber, mbr => mbr.MapFrom(src => src.Car.RegistrationPlateNumber));
        }
    }
}
