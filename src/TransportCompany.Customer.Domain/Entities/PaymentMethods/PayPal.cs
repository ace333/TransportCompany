namespace TransportCompany.Customer.Domain.Entities.PaymentMethods
{
    public class PayPal : PaymentMethod
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAlwaysLoggedIn { get; set; }
    }
}
