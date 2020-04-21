using System;

namespace TransportCompany.Shared.Infrastructure.Model
{
    public sealed class PageInfo
    {
        public PageInfo(int totalRecords, int limit, int offset)
        {
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)limit);
            HasPreviousPage = offset > 0;
            HasNextPage = offset + limit < totalRecords;
        }

        public int TotalRecords { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
    }
}
