using AutoMapper;
using BLL.ModelsDTO;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.IoC;
using MVC.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ILogger<RoomsController> _logger;

        public readonly IRoomService service;
        public readonly IBookingService bookingService;
        public IMapper mapper;

        public RoomsController(ILogger<RoomsController> logger)
        {
            _logger = logger;
            this.service = IoCManage.GetService(typeof(IRoomService)) as IRoomService;
            bookingService = IoCManage.GetService(typeof(IBookingService)) as IBookingService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SyncType = "Asynchronous";
            List<RoomDTO> result = await service.GetAll();
            return View(result);
        }
        [HttpPost]
        public IActionResult Index(List<RoomDTO> models)
        {
            return View(models) ;
        }
        [HttpGet]
        public IActionResult SearchAwailable()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchAwailable(CheckInCheckOutView model)
        {
            return RedirectToAction("IndexAwailable", new { CheckIn = model.CheckIn, CheckOut=model.CheckOut});
        }
        [HttpGet]
        public async Task<IActionResult> IndexAwailable(CheckInCheckOutView model)
        {
            List<RoomDTO> result = await service.GetAvailable(model.CheckIn, model.CheckOut);
            return View(result);
        }
    }
}
