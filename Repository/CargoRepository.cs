using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using SegurancaTrabalho.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CargoRepository : ICargo
    {
        protected readonly DataContext _context;
        public CargoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
            Cargo_Entity obj = await GetById(Id);

            if (obj == null)
            {
                return false;
            }

            try
            {
                _context.Set<Cargo_Entity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<Cargo_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Cargo_Entity>()
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cargo)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cliente)
                    .Include(e => e.Funcionarios).ThenInclude(e => e.Cargo)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cargo_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Cargo_Entity>()
                    .Include(e => e.Funcionarios)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cargo)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cliente)
                    .Where(x => x.Id == Id) .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cargo_Entity> GetCargo(string cargo)
        {
            try
            {
                return await _context.Set<Cargo_Entity>()
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cargo)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cliente)
                    .Include(e => e.Funcionarios)
                    .Where(x => x.Nome == cargo).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cargo_Entity> Post(Cargo_Entity entity)
        {
            try
            {

                await _context.Set<Cargo_Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }


        public async Task<Cargo_Entity> Put(Cargo_Entity entity)
        {
            Cargo_Entity obj = await GetById(entity.Id);

            try
            {
                if (obj == null)
                {
                    return null;
                }

                obj.Nome = !String.IsNullOrWhiteSpace(entity.Nome) ? entity.Nome : obj.Nome;
               

                _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }
    }
}



