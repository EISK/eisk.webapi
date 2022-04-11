namespace Eisk.Core.Exceptions
{
    public class NonExistantEntityException<TEntity> : DomainException<TEntity>

    {
        public NonExistantEntityException(object paramValue, string paramName = "id") : base(
            $"No {typeof(TEntity).Name} exists for given id {paramValue} for parameter {paramName}.", "APP-DATA-ERROR-002")
        {
            
        }
    }
}