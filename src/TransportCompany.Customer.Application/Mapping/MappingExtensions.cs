using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Mapping
{
    public static class MappingExtensions
    {
        public static IReadOnlyCollection<RouteDto> MapRoutes(this IMapper mapper, ICollection<Route> routes)
        {
            return routes
                .Select(x => new RouteDto(x.Id, mapper.Map<AddressDto>(x.DestinationPoint)))
                .ToList();
        }
    }
}
