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
    public sealed class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDTO, BookingInfo>();
            CreateMap<BookingInfo, BookingDTO>();
            CreateMap<CreateBookingDTO, BookingDTO>();
            CreateMap<CreateBookingDTO, BookingInfo>();
        }
    }
}
