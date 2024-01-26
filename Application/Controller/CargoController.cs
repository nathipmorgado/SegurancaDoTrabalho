using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.Dto;

namespace Application.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
            public ICargo _service { get; set; }
            public CargoController(ICargo service)
            {
                _service = service;
            }

            //[Authorize("Bearer")]
            [HttpGet("Cargo")]
            public async Task<ActionResult> Cargo([FromHeader] string nome)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    Cargo_Entity request = new Cargo_Entity() { Nome = nome };
                    var obj = await _service.GetCargo(request.Nome);
                    return Ok(obj);

                }
                catch (ArgumentException e)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }

            //[Authorize("Bearer")]
            [HttpGet("")]
            public async Task<ActionResult> GetAll()
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    return Ok(await _service.GetAll());

                }
                catch (ArgumentException e)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }

            //[Authorize("Bearer")]
            [HttpGet("{id}")]
            public async Task<ActionResult> Get(int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    return Ok(await _service.GetById(id));

                }
                catch (ArgumentException e)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }

            //[Authorize("Bearer")]
            [HttpPost("")]
            public async Task<ActionResult> Post([FromBody] Cargo_Dto dto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
               
                   Cargo_Entity entity = new Cargo_Entity()
                   {
                      Id = dto.Id,
                      Nome = dto.Nome,
                   };

                    return Ok(await _service.Post(entity));
                }
                catch (ArgumentException e)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }

            //[Authorize("Bearer")]
            [HttpPut("")]
            public async Task<ActionResult> Put([FromBody] Cargo_Dto dto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                Cargo_Entity entity = new Cargo_Entity() { Id = dto.Id, Nome = dto.Nome };
                return Ok(await _service.Put(entity));
                }
                catch (ArgumentException e)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }


            //[Authorize("Bearer")]
            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    return Ok(await _service.Delete(id));
                }
                catch (ArgumentException e)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }
        
    }
}

