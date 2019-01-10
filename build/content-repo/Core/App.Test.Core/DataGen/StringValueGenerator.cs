using System;

namespace Test.Core.DataGen
{
    public class StringValueGenerator
    {
        private readonly string _seedValue;
        private readonly bool _generateUniqueValue;

        public StringValueGenerator(bool generateUniqueValue, string seedValue)
        {
            _seedValue = seedValue;
            _generateUniqueValue = generateUniqueValue;
        }

        public override string ToString()
        {
            return !_generateUniqueValue ? _seedValue : _seedValue + "_" + Guid.NewGuid();
        }
    }
}