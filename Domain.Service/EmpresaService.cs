using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.Extensions.Configuration;
using Repository;
using SegurancaTrabalho.Domain.Service.Security;
using SegurancaTrabalho.Repository.Context;
using SegurancaTrabalho.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class EmpresaService : IEmpresa
    {
        private EmpresaRepository _repositorySystem;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;
        SigningConfigurations _a;
        TokenConfigurations _b;
        IConfiguration _c;

        public EmpresaService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
        {
            _repositorySystem = new EmpresaRepository(context);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _a = a;
            _b = b;
            _c = c;
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repositorySystem.Delete(Id);
        }

        public async Task<Empresa_Entity> GetEmpresa (string empresa)
        {
            return await _repositorySystem.GetEmpresa(empresa);
        }

        public async Task<IEnumerable<Empresa_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }

        public async Task<Empresa_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public async Task<Empresa_Entity> Post(Empresa_Entity entity)
        {
            return await _repositorySystem.Post(entity);
        }

        public async Task<Empresa_Entity> Put(Empresa_Entity entity)
        {
            return await _repositorySystem.Put(entity);
        }
    }
}
