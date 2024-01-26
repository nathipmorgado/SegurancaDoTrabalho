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
    public class PermissaoService : IPermissao
    {
        private PermissaoRepository _repositorySystem;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;
        SigningConfigurations _a;
        TokenConfigurations _b;
        IConfiguration _c;

        public PermissaoService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
        {
            _repositorySystem = new PermissaoRepository(context);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _a = a;
            _b = b;
            _c = c;
        }

        public async Task<IEnumerable<Permissao_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }

        public async Task<Permissao_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public Task<Permissao_Entity> Post(Permissao_Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Permissao_Entity> Put(Permissao_Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Permissao_Entity> GetPermissao(string permissao)
        {
            return await _repositorySystem.GetPermissao(permissao);
        }
    }

    
}
