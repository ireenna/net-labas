using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAll();
        Task<BookingDTO> GetById(int id);
        Task<bool> Create(CreateBookingDTO room);
        Task<bool> Update(BookingDTO room);
        Task<bool> Delete(int id);
    }
}
