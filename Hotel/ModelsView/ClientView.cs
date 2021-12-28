using HotelPL.ModelsView.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.ModelsView
{
    public class ClientView : BaseView
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
