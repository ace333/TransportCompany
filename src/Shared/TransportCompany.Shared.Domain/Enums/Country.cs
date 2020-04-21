using System.Runtime.Serialization;

namespace TransportCompany.Shared.Domain.Enums
{
    public enum Country
    {
        [EnumMember(Value = "Poland")]
        Poland = 1,
        [EnumMember(Value = "Ukraine")]
        Ukraine,
        [EnumMember(Value = "Germany")]
        Germany,
        [EnumMember(Value = "Great Britain")]
        GreatBritain,
        [EnumMember(Value = "USA")]
        UnitedStatesOfAmerica
    }
}
