using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var clients = new List<Client>()
            {
                new Client{Id=1,FistName="Irina", LastName="Kobets",Birthday=new DateTime(2002,5,18)},
                new Client{Id=2,FistName="Alex", LastName="Boiko",Birthday=new DateTime(1999,2,10)},
                new Client{Id=3,FistName="Alla", LastName="Kostromicheva",Birthday=new DateTime(1988,2,2)},
                new Client{Id=4,FistName="Iron", LastName="Man",Birthday=new DateTime(1980,1,12)},
                new Client{Id=5,FistName="Ann", LastName="Montgomery",Birthday=new DateTime(1997,5,9)},
            };
            var rooms = new List<Room>()
            {
                new Room{Id=1, Category=Category.Standart, IsAvailable=true, PeopleQuantity=2},
                new Room{Id=2, Category=Category.Standart, IsAvailable=false, PeopleQuantity=4},
                new Room{Id=3, Category=Category.Standart, IsAvailable=true, PeopleQuantity=5},
                new Room{Id=4, Category=Category.Standart, IsAvailable=true, PeopleQuantity=6},
                new Room{Id=5, Category=Category.Premium, IsAvailable=false, PeopleQuantity=3},
                new Room{Id=6, Category=Category.Premium, IsAvailable=true, PeopleQuantity=3},
                new Room{Id=7, Category=Category.VIP, IsAvailable=false, PeopleQuantity=1},
                new Room{Id=8, Category=Category.VIP, IsAvailable=true, PeopleQuantity=1},

            };
            var bookings = new List<BookingInfo>()
            {
                new BookingInfo{Id=1, RoomId=2, CheckIn=DateTime.Now.AddDays(-5), CheckOut=DateTime.Now.AddDays(5),ClientId=3, Cost=100},
                new BookingInfo{Id=2, RoomId=5, CheckIn=DateTime.Now.AddDays(-4), CheckOut=DateTime.Now.AddDays(1),ClientId=4, Cost=200},
                new BookingInfo{Id=3, RoomId=7, CheckIn=DateTime.Now.AddDays(-3), CheckOut=DateTime.Now.AddDays(2),ClientId=5, Cost=350},
                new BookingInfo{Id=4, RoomId=2, CheckIn=DateTime.Now.AddDays(-5), CheckOut=DateTime.Now.AddDays(5),ClientId=3, Cost=100},
            };

            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<Room>().HasData(rooms);
            modelBuilder.Entity<BookingInfo>().HasData(bookings);
        }
    }
}
