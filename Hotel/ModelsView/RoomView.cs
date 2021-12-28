using HotelPL.ModelsView.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.ModelsView
{
    public class RoomView : BaseView
    {
        public CategoryView Category { get; set; }
        public bool IsAvailable { get; set; }
        public int PeopleQuantity { get; set; }
    }
}
