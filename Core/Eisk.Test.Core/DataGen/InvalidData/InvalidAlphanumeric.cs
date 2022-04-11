namespace Eisk.Test.Core.DataGen.InvalidData
{
    public class InvalidAlphanumeric : StringValueGenerator
    {
        public InvalidAlphanumeric(bool generateUniqueValue = true, string value = "invalid_alphanumeric") : base(generateUniqueValue, value)
        {

        }
    }
}