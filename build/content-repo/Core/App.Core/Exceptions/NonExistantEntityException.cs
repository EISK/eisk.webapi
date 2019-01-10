namespace Core.Exceptions
{
    public class NonExistantEntityException<T>: CoreException
        
    {
        public NonExistantEntityException(object paramValue, string paramName = "id") : base(string.Format("No {0} exists for given id {1} for parameter {2}.", typeof(T).Name,  paramValue, paramName), "APP-DATA-ERROR-001")
        {
            
        }
    }
}