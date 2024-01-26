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
    public class CargoService : ICargo
    {
        private CargoRepository _repositorySystem;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;
        SigningConfigurations _a;
        TokenConfigurations _b;
        IConfiguration _c;

        public CargoService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
        {
            _repositorySystem = new CargoRepository(context);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _a = a;
            _b = b;
            _c = c;
        }



        public async Task<Cargo_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public async Task<Cargo_Entity> Post(Cargo_Entity entity)
        {
            return await _repositorySystem.Post(entity);
        }

        public async Task<Cargo_Entity> Put(Cargo_Entity entity)
        {
            return await _repositorySystem.Put(entity); ;
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repositorySystem.Delete(Id);        }

        public async Task<Cargo_Entity> GetCargo(string cargo)
        {
            return await _repositorySystem.GetCargo(cargo);
        }

        public async Task<IEnumerable<Cargo_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }
    }
}
