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
    public class RoomController : IController
    {
        private readonly HttpClient appClient = new HttpClient() { BaseAddress = new Uri("https://localhost:44352/api/") };
        public Dictionary<int, Func<Task>> controllers { get; set; }

        public RoomController()
        {
            controllers = new Dictionary<int, Func<Task>>()
            {
                [1] = GetAll,
                [2] = GetById,
                [3] = Add,
                [4] = GetAwailable,
                [5] = Update,
                [6] = Delete
            };
        }
        public void ShowMenu()
        {
            Console.WriteLine("\nChoose action what you want to do, write the number: " +
                "\n1 - get the list of all rooms" +
                "\n2 - get the room by number" +
                "\n3 - add room" +
                "\n4 - get awailable" +
                "\n5 - update room" +
                "\n6 - delete room");
        }
        public async Task GetAll()
        {
            HttpResponseMessage response = await appClient.GetAsync("room");
            string strResponse = await response.Content.ReadAsStringAsync();
            List<RoomView> result = JsonConvert.DeserializeObject<List<RoomView>>(strResponse);
            result.ForEach(x => Console.WriteLine($"{x.Id}. {Enum.GetName(typeof(CategoryView), x.Category)} Is awailable now: {x.IsAvailable}."));
        }
        public async Task<RoomView> ReturnById()
        {
            Console.WriteLine("Please, write an id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            HttpResponseMessage response = await appClient.GetAsync("room/"+id);
            string strResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RoomView>(strResponse);
        }
        public async Task GetById()
        {
            var x = await ReturnById();
            Console.WriteLine($"{x.Id}. {Enum.GetName(typeof(CategoryView), x.Category)} Is awailable now: {x.IsAvailable}.");

        }
        public async Task GetAwailable()
        {
            Console.WriteLine("CheckIn: ");
            DateTime cin = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("CheckOut: ");
            DateTime cout = Convert.ToDateTime(Console.ReadLine());
            HttpResponseMessage response = await appClient.GetAsync("room/awailable?checkIn="+cin.ToString()+"&checkOut="+cout.ToString());
            string strResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<RoomView>>(strResponse);

            result.ForEach(x => Console.WriteLine($"{x.Id}. {Enum.GetName(typeof(CategoryView), x.Category)}. People: {x.PeopleQuantity}"));
        }
        public async Task Add()
        {
            Console.WriteLine("Category (1-Standart, 2-Prmium, 3-VIP): ");
            int category = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("IsAwailable (0-No, 1-Yes): ");
            bool isaw = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            RoomView client = new RoomView() { Category = (CategoryView)category, IsAvailable = isaw };
            var jsonProj = JsonConvert.SerializeObject(client);
            var data = new StringContent(jsonProj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await appClient.PostAsync($"room", data);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine($"The room was successfully created!");
            }
            else
            {
                Console.WriteLine("There is an error. Please, try again.");
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
                    {
                        Console.WriteLine("New category (1-Standart, 2-Prmium, 3-VIP):: ");
                        client.Category = (CategoryView)Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Is awailable (0-No, 1-Yes): ");
                        client.IsAvailable = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                        break;
                    }
            }
            var jsonProj = JsonConvert.SerializeObject(client);
            var data = new StringContent(jsonProj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await appClient.PutAsync($"room", data);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine($"The room {client.Id} was successfully updated!");
            }
            else
            {
                Console.WriteLine("There is an error. Please, try again.");
            }

        }
        public async Task Delete()
        {
            var client = await ReturnById();
            HttpResponseMessage response = await appClient.DeleteAsync("room/" + client.Id);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine($"The room {client.Id} was successfully deleted!");
            }
            else
            {
                Console.WriteLine("There is an error. Please, try again.");
            }

        }
    }
}
