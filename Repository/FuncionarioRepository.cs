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
    public class FuncionarioRepository : IFuncionario
    {
        protected readonly DataContext _context;
        public FuncionarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {

            Funcionario_Entity obj = await GetById(Id);

            if (obj == null)
            {
                return false;
            }

            try
            {
                _context.Set<Funcionario_Entity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<IEnumerable<Funcionario_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Funcionario_Entity>()
                     .Include(e => e.Clientes)
                     .ThenInclude(e => e.Funcionario)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Funcionario_Entity>()
                    .Include(e => e.Clientes)
                    .ThenInclude(e => e.Funcionario)
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario_Entity> GetFuncionario(string funcionario)
        {
            try
            {
                 return await _context.Set<Funcionario_Entity>()
                    .Include(e => e.Clientes)
                    .ThenInclude(e => e.Funcionario)
                    .Where(x => x.Nome == funcionario)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario_Entity> Post(Funcionario_Entity entity)
        {
            try
            {
                await _context.Set<Funcionario_Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<Funcionario_Entity> Put(Funcionario_Entity entity)
        {
            Funcionario_Entity obj = await GetById(entity.Id);
            
            try
            {
                if (obj == null)
                {
                    return null;
                }

                obj.Nome = !String.IsNullOrWhiteSpace(entity.Nome) ? entity.Nome : obj.Nome;
                obj.RG = !int.IsEvenInteger(entity.RG)? entity.RG : obj.RG;
                obj.CPF = !double.IsEvenInteger(entity.CPF) ? entity.CPF : obj.CPF;
                obj.Endereco = !String.IsNullOrWhiteSpace(entity.Endereco) ? entity.Endereco : obj.Endereco;
                obj.IdCargo = entity.IdCargo != null ? entity.IdCargo : obj.IdCargo;
               

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