using HotelPL.Controllers;
using HotelPL.Controllers.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMainController controller = new MainController();
            while (true)
            {
                Console.Clear();
                int key;
                controller.ShowMenu();
                if (int.TryParse(Console.ReadLine(), out key) && controller.controllers.ContainsKey(key))
                {
                    IController entiController = controller.controllers[key].Invoke();
                    entiController.ShowMenu();
                    if (int.TryParse(Console.ReadLine(), out key) && entiController.controllers.ContainsKey(key))
                    {
                        await entiController.controllers[key].Invoke();
                        Console.ReadKey();
                    }
                }
                
            }
        }
    }
}
