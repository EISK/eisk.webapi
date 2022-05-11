using Eisk.Core.Exceptions;

namespace Eisk.Core.Utils;

public class ExceptionThrower
{

    public static void Throws<T>()
        where T : CoreException, new()
    {
        throw new T();
    }
}
