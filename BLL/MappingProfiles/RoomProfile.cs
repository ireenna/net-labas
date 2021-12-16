using AutoMapper;
using BLL.ModelsDTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MappingProfiles
{
    public sealed class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomDTO, Room>()
                .ForMember(dist=>dist.Category, s => s.MapFrom(x => x.Category));
            CreateMap<Room, RoomDTO>();
        }
    }
}
