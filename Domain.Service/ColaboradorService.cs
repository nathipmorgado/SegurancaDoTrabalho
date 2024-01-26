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
    public class ColaboradorService : IColaborador
        {
            private ColaboradorRepository _repositorySystem;
            private SigningConfigurations _signingConfigurations;
            private TokenConfigurations _tokenConfigurations;
            public IConfiguration _configuration;
            SigningConfigurations _a;
            TokenConfigurations _b;
            IConfiguration _c;

            public ColaboradorService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
            {
                _repositorySystem = new ColaboradorRepository(context);
                _signingConfigurations = signingConfigurations;
                _tokenConfigurations = tokenConfigurations;
                _configuration = configuration;
                _a = a;
                _b = b;
                _c = c;
            }

        

        public async Task<Colaborador_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public async Task<Colaborador_Entity> Post(Colaborador_Entity entity)
        {
            return await _repositorySystem.Post(entity);
        }

        public async Task<Colaborador_Entity> Put(Colaborador_Entity entity)
        {
            return await _repositorySystem.Put(entity); ;
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repositorySystem.Delete(Id);
        }

        public async Task<Colaborador_Entity> GetColaborador(string colaborador, string senha)
        {
            return await _repositorySystem.GetColaborador(colaborador,senha);
        }

        public async Task<IEnumerable<Colaborador_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }

  
    }
}
