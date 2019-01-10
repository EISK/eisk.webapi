namespace Core.Exceptions
{
    public class UpdatingIdIsNotSupported<TEntity>: CoreException
        
    {
        public UpdatingIdIsNotSupported(object paramValue, string paramName = "id") : base(string.Format("Updating {0} field {1} is not supported. Provided value: {2}.", typeof(TEntity).Name,  paramName, paramValue), "APP-DATA-ERROR-001")
        {
            
        }
    }
}