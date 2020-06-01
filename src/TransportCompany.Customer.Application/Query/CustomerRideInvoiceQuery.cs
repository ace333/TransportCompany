using Microsoft.AspNetCore.Mvc;
using TransportCompany.Customer.Application.Query.Base;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.Query
{
    public class CustomerRideInvoiceQuery: CustomerBaseQuery, IQuery<FileResult>
    {
    }
}
