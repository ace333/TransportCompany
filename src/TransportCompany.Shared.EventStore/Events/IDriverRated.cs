namespace TransportCompany.Shared.EventStore.Events
{
    public interface IDriverRated
    {
        int DriverId { get; }
        decimal Grade { get; }
    }
}
