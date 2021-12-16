using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private bool _disposed;
        private Dictionary<Type, object> _repositories;
        public TContext DbContext { get; }

        public UnitOfWork(TContext context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new BaseRepository<TEntity>(DbContext);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            return await DbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);//
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repositories?.Clear();

                    DbContext.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
