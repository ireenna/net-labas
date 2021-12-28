using FluentValidation;
using HotelPL.ModelsView.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.ModelsView
{
    public class BookingView :BaseView
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Cost { get; set; }
        public int? ClientId { get; set; }
        public int? RoomId { get; set; }
    }
}
