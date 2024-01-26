using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.Extensions.Configuration;
using Repository;
using SegurancaTrabalho.Domain.Service.Security;
using SegurancaTrabalho.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ClientesService: IClientes
    {
        private ClientesRepository _repositorySystem;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;
        SigningConfigurations _a;
        TokenConfigurations _b;
        IConfiguration _c;

        public ClientesService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
        {
            _repositorySystem = new ClientesRepository(context);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _a = a;
            _b = b;
            _c = c;
        }

        public async Task<Cliente_Entity> GetCliente(string cliente)
        {
            return await _repositorySystem.GetCliente(cliente);
        }

        public async Task<IEnumerable<Cliente_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }

        public async Task<Cliente_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public async Task<Cliente_Entity> Post(Cliente_Entity entity)
        {
            return await _repositorySystem.Post(entity);
        }

        public async Task<Cliente_Entity> Put(Cliente_Entity entity)
        {
            return await _repositorySystem.Put(entity);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repositorySystem.Delete(Id);
        }
    }
}
