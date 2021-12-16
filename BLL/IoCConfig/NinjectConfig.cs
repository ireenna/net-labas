using AutoMapper;
using BLL.MappingProfiles;
using BLL.ModelsDTO;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IoCConfig
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<BookingDTO>>().To<BookingDTOValidator>();
            Bind<HotelContext>().ToSelf().WithConstructorArgument("options", new DbContextOptionsBuilder<HotelContext>().UseSqlServer("Server=DESKTOP-RG3R0BI\\SQLEXPRESS;Database=NETlaba;Trusted_Connection=True;").Options);
            Bind<IUnitOfWork>().To<UnitOfWork<HotelContext>>();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));

            Bind<IClientService>().To<ClientsService>();
            Bind<IRoomService>().To<RoomsService>();
            Bind<IBookingService>().To<BookingService>();
            
        }
        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookingProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddMaps(GetType().Assembly);
            });

            return config;
        }

    }
}
