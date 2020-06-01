using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Mapping
{
    public static class MappingExtensions
    {
        public static IReadOnlyCollection<AddressDto> MapRoutes(this IMapper mapper, IEnumerable<Route> routes)
            => routes.SelectMany(x => x.GetAddresses)
                .Distinct()
                .Select(x => mapper.Map<AddressDto>(x))
                .ToList();
    }
}
