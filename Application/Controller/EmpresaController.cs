using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace SegurancaTrabalho.Application.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public IEmpresa _service { get; set; }

        public EmpresaController(IEmpresa service)
        {
            _service = service;
        }

        [HttpGet("GetEmpresaByNome")]
        public async Task<ActionResult> GetEmpresaByNome([FromHeader] string nome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Empresa_Entity request = new Empresa_Entity() { Nome = nome};
                var obj = await _service.GetEmpresa(request.Nome);

                    return Ok(obj);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpGet("GetAll")]
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
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
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
    }
}
    

