using AutoMapper;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstractions
{
    public abstract class BaseService
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork db;
        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
            _mapper = mapper;
        }
    }
}
