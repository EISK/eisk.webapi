using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eisk.Core.DataService
{
    public interface IEntityDataService<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetById<TId>(TId id);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}