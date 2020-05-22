using Newtonsoft.Json;

namespace TransportCompany.Shared.Application.Command
{
    public abstract class IdCommand
    {
        [JsonIgnore]
        public int Id { get; private set; }

        public void SetId(int id) => Id = id;
    }
}
