using Eisk.Test.Core.DataGen.FieldGenerators;

namespace Eisk.Test.Core.DataGen.InvalidData;

public class InvalidUri : StringValueGenerator
{
    public InvalidUri(bool generateUniqueValue = true, string value = "invalid_uri") : base(generateUniqueValue, value)
    {

    }
}
