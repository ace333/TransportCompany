using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command.Base
{
    public abstract class CustomerBaseCommand : IdCommand
    {
        public int CustomerId { get; set; }

        public void SetArguments(int customerId, int id)
        {
            CustomerId = customerId;
            SetId(id);
        }
    }
}
