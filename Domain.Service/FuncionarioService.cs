using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.Extensions.Configuration;
using Repository;
using SegurancaTrabalho.Domain.Service.Security;
using SegurancaTrabalho.Repository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class FuncionarioService : IFuncionario
    {
        private FuncionarioRepository _repositorySystem;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;
        SigningConfigurations _a;
        TokenConfigurations _b;
        IConfiguration _c;

        public FuncionarioService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
        {
            _repositorySystem = new FuncionarioRepository(context);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _a = a;
            _b = b;
            _c = c;
        }

        public async Task<Funcionario_Entity> GetFuncionario(string funcionario)
        {
            return await _repositorySystem.GetFuncionario(funcionario);
        }

        public async Task<IEnumerable<Funcionario_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }

        public async Task<Funcionario_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public async Task<Funcionario_Entity> Post(Funcionario_Entity entity)
        {
            return await _repositorySystem.Post(entity);
        }

        public async Task<Funcionario_Entity> Put(Funcionario_Entity entity)
        {
            return await _repositorySystem.Put(entity);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repositorySystem.Delete(Id);
        }
    }
}