using System.Runtime.Serialization;

namespace Core.Enums
{
    public enum Status
    {
        [EnumMember(Value = "No")]
        No,

        [EnumMember(Value = "Yes")]
        Yes,
    }

    public enum PaymentMethod
    {
        [EnumMember(Value = "Bank Card")]
        BankCard,

        [EnumMember(Value = "Cash")]
        Cash
    }
}