namespace TransportCompany.Shared.EventStore.Events
{
    public interface ICustomerRated
    {
        int CustomerId { get; }
        decimal Grade { get; }
    }
}
