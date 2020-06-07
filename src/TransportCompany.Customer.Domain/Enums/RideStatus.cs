using System.Runtime.Serialization;

namespace TransportCompany.Customer.Domain.Enums
{
    public enum RideStatus
    {
        [EnumMember(Value = "Completed")]
        Completed = 1,
        [EnumMember(Value = "Waiting for Driver")]
        WaitingForDriver,
        [EnumMember(Value = "On-Going")]
        OnGoing,
        [EnumMember(Value = "Cancelled")]
        Cancelled
    }
}
