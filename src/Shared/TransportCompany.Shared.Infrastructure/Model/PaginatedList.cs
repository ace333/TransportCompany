using System.Collections.Generic;

namespace TransportCompany.Shared.Infrastructure.Model
{
    public class PaginatedList<TDto> where TDto : class
    {
        public PaginatedList(IReadOnlyCollection<TDto> items, int totalRecords, int limit, int offset)
        {
            Items = items;
            PageInfo = new PageInfo(totalRecords, limit, offset);
        }

        public IReadOnlyCollection<TDto> Items { get; }
        public PageInfo PageInfo { get; }
    }
}
