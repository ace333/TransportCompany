using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class RouteDto
    {
        public RouteDto(int id, AddressDto address)
        {
            Id = id;
            Address = address;
        }

        public int Id { get; }
        public AddressDto Address { get; }
    }
}
