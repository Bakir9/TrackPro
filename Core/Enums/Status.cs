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
        [EnumMember(Value = "Debit Card")]
        DebitCard,

        [EnumMember(Value = "Cash")]
        Cash,
        
        [EnumMember(Value = "Both")]
        Both,
    }
}