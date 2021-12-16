using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BookingInfo:Entity
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Cost { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }


    }
}
