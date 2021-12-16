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
    public sealed class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();
        }
    }
}
