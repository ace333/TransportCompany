using Microsoft.AspNetCore.Mvc;
using TransportCompany.Driver.Application.Query.Base;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Driver.Application.Query
{
    public class DriverRideInvoiceQuery: DriverBaseQuery, IQuery<FileResult>
    {
    }
}
