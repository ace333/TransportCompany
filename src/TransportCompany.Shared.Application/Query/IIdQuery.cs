namespace TransportCompany.Shared.Application.Query
{
    public interface IIdQuery
    {
        int Id { get; }
        void SetId(int id);
    }
}
