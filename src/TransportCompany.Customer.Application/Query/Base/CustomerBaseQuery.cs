using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.Query.Base
{
    public abstract class CustomerBaseQuery : IdQuery
    {
        public int CustomerId { get; set; }

        public void SetArguments(int customerId, int id)
        {
            CustomerId = customerId;
            SetId(id);
        }
    }
}
