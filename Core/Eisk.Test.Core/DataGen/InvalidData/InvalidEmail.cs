namespace Eisk.Test.Core.DataGen.InvalidData;

using FieldGenerators;

public class InvalidEmail : StringValueGenerator
{
    public InvalidEmail(bool generateUniqueValue = true, string value = "invalid_email") : base(generateUniqueValue, value)
    {

    }
}
