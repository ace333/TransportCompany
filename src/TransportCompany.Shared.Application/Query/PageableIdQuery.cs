using Newtonsoft.Json;

namespace TransportCompany.Shared.Application.Query
{
    public abstract class PageableIdQuery: PageableQuery, IIdQuery
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public void SetId(int id) => Id = id;
    }
}
