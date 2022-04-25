using System;

namespace Eisk.Test.Core.DataGen.FieldGenerators;

public class IntegerValueGenerator
{
    private readonly int _maxValue;

    public IntegerValueGenerator(int maxValue = Int32.MaxValue)
    {
        _maxValue = maxValue;
    }

    public int Value()
    {
        return new Random().Next(1, _maxValue);
    }

    public static int RandomInt => new IntegerValueGenerator().Value();
}
