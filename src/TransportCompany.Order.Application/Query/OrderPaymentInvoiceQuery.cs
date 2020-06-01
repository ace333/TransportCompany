using Microsoft.AspNetCore.Mvc;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Order.Application.Query
{
    public sealed class OrderPaymentInvoiceQuery : IdQuery, IQuery<FileResult>
    {
    }
}
