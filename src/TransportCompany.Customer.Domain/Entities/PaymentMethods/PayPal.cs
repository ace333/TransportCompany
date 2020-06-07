namespace TransportCompany.Customer.Domain.Entities.PaymentMethods
{
    public class PayPal : PaymentMethod
    {
        protected PayPal() { }

        public PayPal(string email, string password, string phoneNumber, bool isAlwaysLoggedIn)
        {
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            IsAlwaysLoggedIn = isAlwaysLoggedIn;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAlwaysLoggedIn { get; set; }
    }
}
