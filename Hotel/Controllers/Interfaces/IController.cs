using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.Controllers.Interfaces
{
    public interface IController
    {
        Dictionary<int, Func<Task>> controllers { get; set; }

        void ShowMenu();
    }
}
