using Microsoft.AspNetCore.Mvc;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.Query
{
    public class CustomerRideInvoiceQuery: IdQuery, IQuery<FileResult>
    {
    }
}
