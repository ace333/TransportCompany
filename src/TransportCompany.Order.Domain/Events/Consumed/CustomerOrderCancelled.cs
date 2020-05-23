namespace TransportCompany.Order.Domain.Events.Consumed
{
    public sealed class CustomerOrderCancelled
    {
        public int CustomerId { get; set; }
        public string Comments { get; set; }
    }
}
