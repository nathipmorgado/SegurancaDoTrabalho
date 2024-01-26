using Application.Dto;
using Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Domain.Entities.Entities;

namespace Application.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public IFuncionario _service { get; set; }
        public FuncionarioController(IFuncionario service)
        {
            _service = service;
        }
        //[Authorize("Bearer")]
        [HttpGet("Funcionario")]
        public async Task<ActionResult> Funcionario ([FromHeader] string nome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Funcionario_Entity request = new Funcionario_Entity() { Nome = nome };
                var obj = await _service.GetFuncionario(request.Nome);
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
        public async Task<ActionResult> Post([FromBody] Funcionario_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Funcionario_Entity entity = new Funcionario_Entity()
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    RG = dto.RG,
                    CPF = dto.CPF,
                    Endereco = dto.Endereco,
                    IdCargo = dto.IdCargo,
                    
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
        public async Task<ActionResult> Put([FromBody] Funcionario_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Funcionario_Entity entity = new Funcionario_Entity()
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    RG = dto.RG,
                    CPF = dto.CPF,
                    Endereco = dto.Endereco,
                    IdCargo = dto.IdCargo
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