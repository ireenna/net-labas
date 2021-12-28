using AutoMapper;
using BLL.ModelsDTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;

        public readonly IRoomService service;
        public IMapper mapper;

        public RoomController(ILogger<RoomController> logger, IRoomService service)
        {
            _logger = logger;
            this.service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<RoomDTO>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpGet("awailable")]
        public async Task<IEnumerable<RoomDTO>> GetAwailable([FromQuery] DateTime checkIn, DateTime chekOut)
        {
            return await service.GetAvailable(checkIn, chekOut);
        }
        [HttpGet("{id}")]
        public async Task<RoomDTO> GetById(int id)
        {
            return await service.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RoomDTO client)
        {
            try
            {
                var result = await service.Create(client);
                if (result)
                {
                    return Created("project", client);
                }
                else
                {
                    throw new Exception("There is an error. Please, try again.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] RoomDTO client, [FromRoute] int id)
        {
            try
            {
                if(client.Id == id)
                {
                    var result = await service.Update(client);
                    if (result)
                    {
                        return Ok(client);
                    }
                    else
                    {
                        throw new Exception("There is an error. Please, try again.");
                    }
                }
                else
                {
                    throw new Exception("There is an error. Please, try again.");

                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await service.Delete(id);
                if (result)
                {
                    return Ok($"The room {id} was successfully deleted!");
                }
                else
                {
                    throw new Exception("There is an error. Please, try again.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
