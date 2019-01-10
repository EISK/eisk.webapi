namespace Core.Exceptions
{
    public class NullInputEntityException: CoreException
    {
        public NullInputEntityException() : base("Input object to be created or updated is null.", "APP-DATA-ERROR-002")
        {
            
        }
    }
}