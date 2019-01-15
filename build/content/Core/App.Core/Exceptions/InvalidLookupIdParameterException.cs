namespace Core.Exceptions
{
    public class InvalidLookupIdParameterException<TEntity>: CoreException
    {
        public InvalidLookupIdParameterException(string paramName = "id") : base(string.Format("Invalid lookup parameter: {0} to find {1}.", paramName, typeof(TEntity).Name), "APP-DATA-ERROR-001")
        {

        }
    }
}