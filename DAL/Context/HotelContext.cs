using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class HotelContext : DbContext
    {
        public DbSet<Room> Rooms { get; private set; }
        public DbSet<Client> Clients { get; private set; }
        public DbSet<BookingInfo> Bookings { get; private set; }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
