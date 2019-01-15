namespace Core.ExtensionMethods
{
    public static class ObjectExtensions
    {
        public static bool IsNullOrEmpty<T>(this T value)
        {
            if (typeof(T) == typeof(string))
                return string.IsNullOrEmpty(value as string);

            return value == null || value.Equals(default(T));
        }

        public static T EmptyIfNull<T>(this T obj) where T : new()
        {
            if (obj == null) return new T();

            return obj;
        }
    }
}