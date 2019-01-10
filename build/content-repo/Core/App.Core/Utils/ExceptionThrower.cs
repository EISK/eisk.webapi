using System;
using System.Linq;
using Core.Exceptions;

namespace Core.Utils
{
    public class ExceptionThrower
    {

        public static void Throws<T>()
            where T : CoreException, new()
        {
            throw new T();
        }

        public static void Throws<T>(string message)
            where T : CoreException, new()
        {
            var type = typeof(T);
            var constructors = type.GetConstructors();
            if (constructors.Length == 0)
                throw new NotSupportedException("Constructor should have atleast one argument.");

            var ctor = constructors[0];

            var defaultValues = ctor.GetParameters().Select(p => p.DefaultValue).ToArray();
            if (defaultValues.Length == 0)
                throw new NotSupportedException("Constructor should have atleast one argument.");

            defaultValues[0] = message;

            var error = (T)Activator.CreateInstance(typeof(T), defaultValues);

            throw error;
        }
        
    }
}