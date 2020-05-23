namespace TransportCompany.Shared.Infrastructure.Config
{
    public class RabbitMqConfig
    {
        public RabbitMqConfig(string host, string user, string password, string queueName)
        {
            Host = host;
            User = user;
            Password = password;
            QueueName = queueName;
        }

        public string Host { get; }
        public string User { get; }
        public string Password { get; }
        public string QueueName { get; }
    }
}
