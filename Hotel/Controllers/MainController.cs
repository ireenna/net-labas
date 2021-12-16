using HotelPL.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.Controllers
{
    class MainController : IMainController
    {
        public Dictionary<int, Func<IController>> controllers { get; set; }

        public MainController()
        {
            controllers = new Dictionary<int, Func<IController>>()
            {
                [1] = () => { return new RoomController(); },
                [2] = () => { return new ClientController(); },
                [3] = () => { return new BookingController(); }
            };
        }

        public void ShowMenu()
        {
            Console.WriteLine("\nChoose what you want to do: " +
                "\n1 - work with rooms" +
                "\n2 - work with clients" +
                "\n3 - work with bookings");
        }

    }
}
