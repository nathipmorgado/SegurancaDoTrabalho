using Application.Dto;
using AutoMapper;
using Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SegurancaTrabalho.Domain.Entities.Entities;
using System.Net;
using System.Threading.Tasks;
using System;
using Domain.Entities.Entities;
using System.Collections.Generic;

namespace Application.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        public IColaborador _service { get; set; }
        public ColaboradorController(IColaborador service)
        {
            _service = service;
        }
        //[Authorize("Bearer")]
        [HttpGet("ColaboradorLogin")]
        public async Task<ActionResult> ColaboradorLogin([FromHeader] string usuario, [FromHeader] string senha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Colaborador_Entity request = new Colaborador_Entity() { Usuario = usuario, Senha = senha};
                var obj = await _service.GetColaborador(request.Usuario, request.Senha);

                Login_Dto retorno = new Login_Dto();
                retorno.colaborador = new Colaborador_Dto();
                retorno.colaborador.Id = obj.Id;
                retorno.colaborador.Usuario = obj.Usuario;
                retorno.colaborador.Senha = obj.Senha;
                retorno.colaborador.PermissaoId = obj.PermissaoId;
                retorno.colaborador.IdEmpresa = obj.IdEmpresa;
                retorno.colaborador.Nome = obj.Nome;
                retorno.colaborador.RG = obj.RG;
                retorno.colaborador.CPF = obj.CPF;
                retorno.colaborador.Endereco = obj.Endereco;
                retorno.colaborador.NumeroEndereco = obj.NumeroEndereco;
                retorno.colaborador.Cidade = obj.Cidade;
                retorno.colaborador.CEP = obj.CEP;
                retorno.colaborador.ExclusaoLogica = obj.ExclusaoLogica;

                retorno.permissao = new Permissao_Dto();
                retorno.permissao.Id = obj.Permissao.Id;
                retorno.permissao.TipoPermissao = obj.Permissao.TipoPermissao;

                retorno.empresa = new Empresa_Dto();
                retorno.empresa.Id = obj.Empresa.Id;
                retorno.empresa.Nome = obj.Empresa.Nome;

                retorno.clientes = new List<Cliente_Dto>();
                foreach (var resultado in obj.ClienteColaboradores)
                {
                    Cliente_Dto objCliente = new Cliente_Dto();
                    objCliente.Id = resultado.Cliente.Id;
                    objCliente.Nome = resultado.Cliente.Nome;
                    objCliente.IdEmpresa = resultado.Cliente.IdEmpresa;

                    retorno.clientes.Add(objCliente);
                }

                return Ok(retorno);

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
        public async Task<ActionResult> Post([FromBody] Colaborador_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Colaborador_Entity entity = new Colaborador_Entity()
                {
                    Id = dto.Id,
                    Usuario = dto.Usuario,
                    Senha = dto.Senha,
                    PermissaoId = dto.PermissaoId,
                    IdEmpresa = dto.IdEmpresa,
                    Nome = dto.Nome,
                    RG = dto.RG,
                    CPF = dto.CPF,
                    Endereco = dto.Endereco,
                    NumeroEndereco = dto.NumeroEndereco,
                    Cidade = dto.Cidade,
                    CEP = dto.CEP,
                    ExclusaoLogica = dto.ExclusaoLogica,
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
        public async Task<ActionResult> Put([FromBody] Colaborador_Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Colaborador_Entity entity = new Colaborador_Entity()
                {
                    Id = dto.Id,
                    Usuario = dto.Usuario,
                    Senha = dto.Senha,
                    IdEmpresa = dto.IdEmpresa,
                    PermissaoId = dto.PermissaoId,
                    Nome = dto.Nome,
                    RG = dto.RG,
                    CPF = dto.CPF,
                    Endereco = dto.Endereco,
                    NumeroEndereco = dto.NumeroEndereco,
                    Cidade = dto.Cidade,
                    CEP = dto.CEP,
                    ExclusaoLogica = dto.ExclusaoLogica,
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