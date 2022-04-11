namespace Eisk.Core.Exceptions
{
    public class NullInputEntityException <TEntity>: DomainException<TEntity>
    {
        public NullInputEntityException() : base("Input object to be created or updated is null.", "APP-DATA-ERROR-003")
        {
            
        }
    }
}