using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Shared.Infrastructure.Extensions
{
    public static class PagingExtensions
    {
        public static async Task<PaginatedList<TDto>> AsPaginatedList<TDto>(this IQueryable<TDto> queryable, PagingElements pagingElements) 
            where TDto : class
        {
            var count = queryable.Count();
            var items = await queryable.Skip(pagingElements.Offset).Take(pagingElements.Limit)
                .ToListAsync();

            return new PaginatedList<TDto>(items, count, pagingElements.Limit, pagingElements.Offset);
        }
    }
}
