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
    public class RoomsService : BaseService, IRoomService
    {
        public IRepository<Room> repository;
        public IRepository<BookingInfo> bookingrepository;
        public RoomsService(IMapper mapper, IUnitOfWork unitOfWork):base(mapper,unitOfWork)
        {
            repository = db.GetRepository<Room>();
            bookingrepository = db.GetRepository<BookingInfo>();
        }
        public async Task<List<RoomDTO>> GetAll()
        {
            var result = await repository.Get();
            return _mapper.Map<List<Room>, List<RoomDTO>>(result.ToList());
        }
        public async Task<RoomDTO> GetById(int id)
        {
            var result = await repository.GetByID(id);
            return _mapper.Map<Room, RoomDTO>(result);
        }
        public async Task<List<RoomDTO>> GetAvailable(DateTime checkIn, DateTime checkOut)
        {
            var allbookings = (await bookingrepository.Get()).ToList();
            var allrooms = (await repository.Get()).ToList();

            var roomsBooked = from b in allbookings
                              where
                                      ((checkIn >= b.CheckIn) && (checkIn <= b.CheckOut)) ||
                                      ((checkOut >= b.CheckIn) && (checkOut <= b.CheckOut)) ||
                                      ((checkIn <= b.CheckIn) && (checkOut >= b.CheckIn) && (checkOut <= b.CheckOut)) ||
                                      ((checkIn >= b.CheckIn) && (checkIn <= b.CheckOut) && (checkOut >= b.CheckOut)) ||
                                      ((checkIn <= b.CheckIn) && (checkOut >= b.CheckOut))
                              select b;


            var availableRooms = allrooms.Where(r => !roomsBooked.Any(b => b.RoomId == r.Id));

            var result = _mapper.Map<List<Room>, List<RoomDTO>>(availableRooms.ToList());
            return result;

        }
        public async Task<bool> Create(RoomDTO room)
        {
            try
            {
                await repository.Insert(_mapper.Map<RoomDTO, Room>(room));
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public async Task<bool> Update(RoomDTO room)
        {
            try
            {
                await repository.Insert(_mapper.Map<RoomDTO, Room>(room));
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
