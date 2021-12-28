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
    public class BookingService : BaseService, IBookingService
    {
        public IRepository<BookingInfo> repository;
        public IRepository<Client> clientRepository;
        public IRepository<Room> roomRepository;
        public IRoomService roomService;
        public BookingService(IMapper mapper, IUnitOfWork unitOfWork, IRoomService rooms) : base(mapper, unitOfWork)
        {
            repository = db.GetRepository<BookingInfo>();
            clientRepository = db.GetRepository<Client>();
            roomRepository = db.GetRepository<Room>();
            roomService = rooms;
        }
        public async Task<List<BookingDTO>> GetAll()
        {
            var result = (await repository.Get()).ToList();
            return _mapper.Map<List<BookingInfo>, List<BookingDTO>>(result);
        }
        public async Task<BookingDTO> GetById(int id)
        {
            var result = await repository.GetByID(id);
            return _mapper.Map<BookingInfo, BookingDTO>(result);
        }
        
        public async Task<bool> Create(CreateBookingDTO room)
        {
            var result = await clientRepository.GetByID(room.ClientId);
            if (result is null)
            {
               throw new KeyNotFoundException("No such client");

            }
            var roomresult = await roomRepository.GetByID(room.RoomId);
            if(roomresult is null) 
            {
               throw new KeyNotFoundException("No such room");
            }
            var awailable = await roomService.GetAvailable(room.CheckIn, room.CheckOut);
            var isAwailable = awailable.Where(x => x.Id == room.RoomId);
                if (isAwailable.Count() == 0)
            {
                throw new Exception("The room is not awailable in this period");
            }
            await repository.Insert(_mapper.Map<CreateBookingDTO, BookingInfo>(room));
            return true;

        }
        public async Task<bool> Update(BookingDTO room)
        {
            try
            {
                //var result1 = (await repository.Get()).Where(x=>x.Id == room.Id).Count();
                //if (result1 == 0)
                //{
                //    throw new KeyNotFoundException("No such booking");
                //}
                var result = await clientRepository.GetByID(room.ClientId);
                if (result is null)
                {
                    throw new KeyNotFoundException("No such client");

                }
                var roomresult = await roomRepository.GetByID(room.RoomId);
                if (roomresult is null)
                {
                    throw new KeyNotFoundException("No such room");
                }
                await repository.Update(_mapper.Map<BookingDTO, BookingInfo>(room));
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Wrong data");
            }
            
            
        }
        public async Task<bool> Delete(int id)
        {
            var result = await clientRepository.GetByID(id);
            if (result is null)
            {
                throw new KeyNotFoundException("No such booking");
            }
            await repository.Delete(id);
            return true;
        }
    }
}
