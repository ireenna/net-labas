using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAll();
        Task<List<RoomDTO>> GetAvailable(DateTime checkIn, DateTime checkOut);
        Task<RoomDTO> GetById(int id);
        Task<bool> Create(RoomDTO room);
        Task<bool> Update(RoomDTO room);
        Task<bool> Delete(int id);

    }
}
