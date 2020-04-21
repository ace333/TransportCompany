using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Shared.Application.Query
{
    public abstract class PageableQuery
    {
        public int Limit { get; set; }
        public int Offset { get; set; }

        public PagingElements GetPagingElements() => new PagingElements(Limit, Offset);
    }
}
