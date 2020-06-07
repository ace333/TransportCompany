using System.Runtime.Serialization;

namespace TransportCompany.Driver.Domain.Enums
{
    public enum RideStatus
    {
        [EnumMember(Value = "Completed")]
        Completed = 1,
        [EnumMember(Value = "On the way to Customer")]
        OnTheWayToCustomer,
        [EnumMember(Value = "On-Going")]
        OnGoing,
        [EnumMember(Value = "Cancelled")]
        Cancelled
    }
}
