using System;
using System.Collections.Generic;
using System.Text;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.Query
{
    public class CustomerDetailsQuery: IdQuery, IQuery<CustomerDetailsQueryDto>
    {
    }
}
