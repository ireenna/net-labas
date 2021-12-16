using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetAll();
        Task<ClientDTO> GetById(int id);
        Task<bool> Create(ClientDTO room);
        Task<bool> Update(ClientDTO room);
        Task<bool> Delete(int id);
    }
}
