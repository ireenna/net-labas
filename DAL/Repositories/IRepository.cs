using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Update(TEntity entityToUpdate);
        Task Delete(TEntity entityToDelete);
        Task Delete(object id);
    }
}
