namespace TransportCompany.Shared.Infrastructure.Model
{
    public sealed class PagingElements
    {
        public PagingElements(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }

        public int Limit { get; }
        public int Offset { get; }
    }
}
