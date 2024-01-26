using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.Dto;
using System.Collections.Generic;

namespace Application.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController: ControllerBase
    {
        public IClientes _service { get; set; }
        public ClientesController(IClientes service)
        {
            _service = service;
        }
        //[Authorize("Bearer")]
        [HttpGet("Clientes")]
        public async Task<ActionResult> Clientes([FromHeader] string nome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Cliente_Entity request = new Cliente_Entity() { Nome = nome };
                var obj = await _service.GetCliente(request.Nome);
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
        public async Task<ActionResult> Post([FromBody] Cliente_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Cliente_Entity entity = new Cliente_Entity() 
                {
                    Id = dto.Id, 
                    Nome = dto.Nome, 
                    IdEmpresa = dto.IdEmpresa,
                    IdFuncionario = dto.IdFuncionario,  
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
        public async Task<ActionResult> Put([FromBody] Cliente_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Cliente_Entity entity = new Cliente_Entity() 
                { 
                    Id = dto.Id, 
                    Nome = dto.Nome,
                    IdEmpresa = dto.IdEmpresa,
                    IdFuncionario = dto.IdFuncionario
                };
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

