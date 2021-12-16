using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Client:Entity
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
