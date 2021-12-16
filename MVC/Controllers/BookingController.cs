using AutoMapper;
using BLL.ModelsDTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.IoC;
using MVC.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;

        public readonly IBookingService service;
        public IMapper mapper;

        public BookingController(ILogger<BookingController> logger)
        {
            _logger = logger;
            this.service = IoCManage.GetService(typeof(IBookingService)) as IBookingService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SyncType = "Asynchronous";
            List<BookingDTO> result = await service.GetAll();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            
            ViewBag.SyncType = "Asynchronous";
            BookingDTO result = await service.GetById(Id);
            
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookingDTO std)
        {
            ViewBag.SyncType = "Asynchronous";
            bool result = await service.Update(std);
            
            //if (result)
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingDTO std)
        {
            ViewBag.SyncType = "Asynchronous";
            bool result = await service.Create(std);

            return RedirectToAction("Index");

        }
        
    }
}
