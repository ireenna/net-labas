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
    public class RoomController : IController
    {
        public readonly IRoomService service;
        public Dictionary<int, Func<Task>> controllers { get; set; }

        public RoomController()
        {
            service = Configuration.GetService(typeof(IRoomService)) as IRoomService;
            controllers = new Dictionary<int, Func<Task>>()
            {
                [1] = GetAll,
                [2] = GetById,
                [3] = Add,
                [4] = Update,
                [5] = Delete
            };
        }
        public void ShowMenu()
        {
            Console.WriteLine("\nChoose action what you want to do, write the number: " +
                "\n1 - get the list of all rooms" +
                "\n2 - get the room by number" +
                "\n3 - add room" +
                "\n4 - update room" +
                "\n5 - delete room");
        }
        public async Task GetAll()
        {
            List<RoomDTO> result = await service.GetAll();
            result.ForEach(x => Console.WriteLine($"{x.Id}. {Enum.GetName(typeof(CategoryDTO), x.Category)} Is awailable now: {x.IsAvailable}."));
        }
        public async Task<RoomDTO> ReturnById()
        {
            Console.WriteLine("Please, write an id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return await service.GetById(id);
        }
        public async Task GetById()
        {
            var x = await ReturnById();
            Console.WriteLine($"{x.Id}. {Enum.GetName(typeof(CategoryDTO), x.Category)} Is awailable now: {x.IsAvailable}.");

        }
        public async Task Add()
        {
            Console.WriteLine("Category (1-Standart, 2-Prmium, 3-VIP): ");
            int category = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("IsAwailable (0-No, 1-Yes): ");
            bool isaw = Convert.ToBoolean(Console.ReadLine());
            RoomDTO client = new RoomDTO() { Category = (CategoryDTO)category, IsAvailable = isaw };

            var result = await service.Create(client);
            if (result)
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
                        client.Category = (CategoryDTO)Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Is awailable (0-No, 1-Yes): ");
                        client.IsAvailable = Convert.ToBoolean(Console.ReadLine());
                        break;
                    }
            }

            var result = await service.Update(client);
            if (result)
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
            var result = await service.Delete(client.Id);
            if (result)
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
