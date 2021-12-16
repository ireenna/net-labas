using AutoMapper;
using BLL.ModelsDTO;
using BLL.Services.Abstractions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClientsService : BaseService, IClientService
    {
        public IRepository<Client> repository;
        public ClientsService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            repository = db.GetRepository<Client>();
        }
        public async Task<List<ClientDTO>> GetAll()
        {
            var result = (await repository.Get()).ToList();
            return _mapper.Map<List<Client>, List<ClientDTO>>(result);
        }
        public async Task<ClientDTO> GetById(int id)
        {
            var result = await repository.GetByID(id);
            return _mapper.Map<Client, ClientDTO>(result);
        }
        public async Task<bool> Create(ClientDTO room)
        {
            try
            {
                await repository.Insert(_mapper.Map<ClientDTO, Client>(room));
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> Update(ClientDTO room)
        {
            try
            {
                await repository.Insert(_mapper.Map<ClientDTO, Client>(room));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                await repository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
