namespace TransportCompany.Shared.Infrastructure.Config
{
    public class RabbitMqConfig
    {
        public RabbitMqConfig(string host, string user, string password)
        {
            Host = host;
            User = user;
            Password = password;
        }

        public string Host { get; }
        public string User { get; }
        public string Password { get; }
    }
}
