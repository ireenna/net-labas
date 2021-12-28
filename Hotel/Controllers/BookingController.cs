using HotelPL.Controllers.Interfaces;
using HotelPL.ModelsView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.Controllers
{
    public class BookingController : IController
    {

        private readonly HttpClient appClient = new HttpClient() { BaseAddress = new Uri("https://localhost:44352/api/") };
        public Dictionary<int, Func<Task>> controllers { get; set; }


        public BookingController()
        {
            controllers = new Dictionary<int, Func<Task>>()
            {
                [1] = GetAll,
                [2] = GetById,
                [3] = Add,
                [4] = Update,
                [5] = Delete,

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
            HttpResponseMessage response = await appClient.GetAsync("booking");
            string strResponse = await response.Content.ReadAsStringAsync();
            List<BookingView> result = JsonConvert.DeserializeObject<List<BookingView>>(strResponse);
            result.ForEach(x => Console.WriteLine($"{x.Id}. Room: {x.RoomId}. Client: {x.ClientId}. Cost: {x.Cost}. Period: {x.CheckIn} - {x.CheckOut}."));
        }
        public async Task<BookingView> ReturnById()
        {
            Console.WriteLine("Please, write an id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            HttpResponseMessage response = await appClient.GetAsync("booking/"+id);
            string strResponse = await response.Content.ReadAsStringAsync();
            BookingView result = JsonConvert.DeserializeObject<BookingView>(strResponse);
            return result;
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
            CreateBookingView client = new CreateBookingView() { ClientId = clientId, RoomId = roomId, Cost = cost, CheckIn = cin, CheckOut=cout };
            try
            {
                var jsonProj = JsonConvert.SerializeObject(client);
                var data = new StringContent(jsonProj, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await appClient.PostAsync($"booking", data);
                if (response.StatusCode == HttpStatusCode.Created)
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
            Console.WriteLine("Choose what you want to change:" +
               "\n 1. Category." +
               "\n 2. Is awailable.");

            int comand = Convert.ToInt32(Console.ReadLine());

            switch (comand)
            {
                case 1:
                    Console.WriteLine("ClientId: ");
                    client.ClientId = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("RoomId: ");
                    client.RoomId = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Cost: ");
                    client.Cost = Convert.ToDecimal(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("CheckIn: ");
                    client.CheckIn = Convert.ToDateTime(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("CheckOut: ");
                    client.CheckOut = Convert.ToDateTime(Console.ReadLine());
                    break;
                default:
                    break;
            }
            var jsonProj = JsonConvert.SerializeObject(client);
            var data = new StringContent(jsonProj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await appClient.PutAsync($"booking", data);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine($"The booking {client.Id} was successfully updated!");
            }
            else
            {
                Console.WriteLine("There is an error. Please, try again.");
            }

            Console.WriteLine("Sorry, not implemented");
        }
        public async Task Delete()
        {
            var client = await ReturnById();
            HttpResponseMessage response = await appClient.DeleteAsync("booking" + client.Id);
            if (response.StatusCode == HttpStatusCode.OK)
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

