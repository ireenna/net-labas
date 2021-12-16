using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Room : Entity
    {
        public Category Category { get; set; }
        public bool IsAvailable { get; set; }
        public int PeopleQuantity { get; set; }
    }
}
