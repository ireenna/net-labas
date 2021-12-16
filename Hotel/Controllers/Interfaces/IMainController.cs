using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.Controllers.Interfaces
{
    public interface IMainController
    {
        public Dictionary<int, Func<IController>> controllers { get; set; }

        void ShowMenu();
    }
}
