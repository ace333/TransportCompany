namespace TransportCompany.Customer.Domain.Events.Consumed
{
    public class CustomerRated
    {
        public int CustomerId { get; set; }
        public decimal Grade { get; set; }
    }
}
