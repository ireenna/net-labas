using BLL.ModelsDTO;
using BLL.Services;
using BLL.Services.Interfaces;
using HotelPL.Configurations;
using HotelPL.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.Controllers
{
    public class BookingController : IController
    {
        public readonly IBookingService service;
        public Dictionary<int, Func<Task>> controllers { get; set; }

        public BookingController()
        {
            service = Configuration.GetService(typeof(IBookingService)) as IBookingService;
            controllers = new Dictionary<int, Func<Task>>()
            {
                [1] = GetAll,
                [2] = GetById,
                [3] = Add,
                [4] = Update,
                [5] = Delete,
                //[6] = GetAwailable

            };
        }
        public void ShowMenu()
        {
            Console.WriteLine("\nChoose action what you want to do, write the number: " +
                "\n1 - get the list of all bookings" +
                "\n2 - get the booking by id" +
                "\n3 - book a room" +
                "\n4 - update booking" +
                "\n5 - delete booking" +
                "\n6 - get awailable rooms");
        }
        public async Task GetAll()
        {
            List<BookingDTO> result = await service.GetAll();
            result.ForEach(x => Console.WriteLine($"{x.Id}. Room: {x.RoomId}. Client: {x.ClientId}. Cost: {x.Cost}. Period: {x.CheckIn} - {x.CheckOut}."));
        }
        //public async Task GetAwailable()
        //{
        //    Console.WriteLine("CheckIn: ");
        //    DateTime cin = Convert.ToDateTime(Console.ReadLine());
        //    Console.WriteLine("CheckOut: ");
        //    DateTime cout = Convert.ToDateTime(Console.ReadLine());
        //    List<RoomDTO> result = await service.GetAvailable(cin,cout);
        //    result.ForEach(x=>Console.WriteLine($"{x.Id}. {Enum.GetName(typeof(CategoryDTO), x.Category)}. People: {x.PeopleQuantity}"));
        //}
        public async Task<BookingDTO> ReturnById()
        {
            Console.WriteLine("Please, write an id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return await service.GetById(id);
        }
        public async Task GetById()
        {
            var x = await ReturnById();
            Console.WriteLine($"{x.Id}. Room: {x.RoomId}. Client: {x.ClientId}. Cost: {x.Cost}. Period: {x.CheckIn} - {x.CheckOut}.");

        }
        public async Task Add()
        {
            Console.WriteLine("ClientId: ");
            int clientId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("RoomId: ");
            int roomId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cost: ");
            decimal cost = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("CheckIn: ");
            DateTime cin = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("CheckOut: ");
            DateTime cout = Convert.ToDateTime(Console.ReadLine());
            BookingDTO client = new BookingDTO() { ClientId = clientId, RoomId = roomId, Cost = cost, CheckIn = cin, CheckOut=cout };
            try
            {
                var result = await service.Create(client);
                if (result)
                {
                    Console.WriteLine($"The booking of the room {client.RoomId} by client {client.ClientId} was successfully created!");
                }
                else
                {
                    throw new Exception("There is an error. Please, try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        public async Task Update()
        {
            var client = await ReturnById();
            Console.WriteLine("Sorry, not implemented");

            

        }
        public async Task Delete()
        {
            var client = await ReturnById();
            var result = await service.Delete(client.Id);
            if (result)
            {
                Console.WriteLine($"The booking {client.Id} was successfully deleted!");
            }
            else
            {
                Console.WriteLine("There is an error. Please, try again.");
            }

        }
    }
}

