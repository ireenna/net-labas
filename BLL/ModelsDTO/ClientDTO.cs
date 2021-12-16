using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO
{
    public class ClientDTO : DTO
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
