using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO
{
    public class RoomDTO : DTO
    {
        public CategoryDTO Category { get; set; }
        public bool IsAvailable { get; set; }
        public int PeopleQuantity { get; set; }
    }
}
