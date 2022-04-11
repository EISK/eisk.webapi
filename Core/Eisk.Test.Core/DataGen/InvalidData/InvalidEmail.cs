namespace Eisk.Test.Core.DataGen.InvalidData
{
    public class InvalidEmail : StringValueGenerator
    {
        public InvalidEmail(bool generateUniqueValue = true, string value = "invalid_email") : base(generateUniqueValue, value)
        {

        }
    }
}