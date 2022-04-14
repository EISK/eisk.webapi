namespace Eisk.Test.Core.DataGen.InvalidData
{
    using FieldGenerators;

    public class InvalidUri : StringValueGenerator
    {
        public InvalidUri(bool generateUniqueValue = true, string value = "invalid_uri") : base(generateUniqueValue, value)
        {

        }
    }
}