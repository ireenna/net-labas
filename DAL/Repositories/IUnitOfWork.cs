using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false);

        //IRepository<Room> Rooms { get; }
        //IRepository<BookingInfo> Bookings { get; }
        //IRepository<Client> Clients { get; }
    }
}
