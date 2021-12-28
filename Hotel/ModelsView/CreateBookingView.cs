using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPL.ModelsView
{
    public class CreateBookingView
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Cost { get; set; }
        public int? ClientId { get; set; }
        public int? RoomId { get; set; }
    }
}
