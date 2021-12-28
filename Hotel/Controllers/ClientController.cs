//using HotelPL.Controllers.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HotelPL.Controllers
//{
//    public class ClientController : IController
//    {
//        public Dictionary<int, Func<Task>> controllers { get; set; }

//        public ClientController()
//        {
//            controllers = new Dictionary<int, Func<Task>>()
//            {
//                [1] = GetAll,
//                [2] = GetById,
//                [3] = Add,
//                [4] = Update,
//                [5] = Delete
//            };
//        }
//        public void ShowMenu()
//        {
//            Console.WriteLine("\nChoose action what you want to do, write the number: " +
//                "\n1 - get the list of all clients" +
//                "\n2 - get the client by id" +
//                "\n3 - add client" +
//                "\n4 - update client" +
//                "\n5 - delete client");
//        }
//        public async Task GetAll()
//        {
//            List<ClientDTO> result = await service.GetAll();
//            result.ForEach(x => Console.WriteLine($"{x.Id}. {x.FistName} {x.LastName}. {(int)((DateTime.Now - x.Birthday).TotalDays / 365.242199)} y.o."));
//        }
//        public async Task<ClientDTO> ReturnById()
//        {
//            Console.WriteLine("Please, write an id: ");
//            int id = Convert.ToInt32(Console.ReadLine());
//            return await service.GetById(id);
//        }
//        public async Task GetById()
//        {
//            var x = await ReturnById();
//            Console.WriteLine($"{x.Id}. {x.FistName} {x.LastName}. {(int)((DateTime.Now - x.Birthday).TotalDays / 365.242199)} y.o.");

//        }
//        public async Task Add()
//        {
//            Console.WriteLine("Name: ");
//            string name = Console.ReadLine();
//            Console.WriteLine("Last name: ");
//            string lastname = Console.ReadLine();
//            Console.WriteLine("Birthday: ");
//            DateTime bd = Convert.ToDateTime(Console.ReadLine());
//            ClientDTO client = new ClientDTO() { FistName = name, LastName = lastname, Birthday = bd };

//            var result = await service.Create(client);
//            if (result)
//            {
//                Console.WriteLine($"The client {client.FistName} {client.FistName} was successfully created!");
//            }
//            else
//            {
//                Console.WriteLine("There is an error. Please, try again.");
//            }

//        }
//        public async Task Update()
//        {
//            var client = await ReturnById();
//            Console.WriteLine("Choose what you want to change:" +
//                "\n 1. First name." +
//                "\n 2. Last name." +
//                "\n. 3. Birthday ");

//            int comand = Convert.ToInt32(Console.ReadLine());

//            switch (comand)
//            {
//                case 1:
//                    {
//                        Console.WriteLine("New name: ");
//                        client.FistName = Console.ReadLine();
//                        break;
//                    }
//                case 2:
//                    {
//                        Console.WriteLine("New last name: ");
//                        client.LastName = Console.ReadLine();
//                        break;
//                    }
//                case 3:
//                    {
//                        Console.WriteLine("New birthday: ");
//                        client.Birthday = Convert.ToDateTime(Console.ReadLine());
//                        break;
//                    }
//            }

//            var result = await service.Update(client);
//            if (result)
//            {
//                Console.WriteLine($"The client {client.FistName} {client.FistName} was successfully updated!");
//            }
//            else
//            {
//                Console.WriteLine("There is an error. Please, try again.");
//            }

//        }
//        public async Task Delete()
//        {
//            var client = await ReturnById();
//            var result = await service.Delete(client.Id);
//            if (result)
//            {
//                Console.WriteLine($"The client {client.FistName} {client.FistName} was successfully deleted!");
//            }
//            else
//            {
//                Console.WriteLine("There is an error. Please, try again.");
//            }

//        }
//    }
//}
