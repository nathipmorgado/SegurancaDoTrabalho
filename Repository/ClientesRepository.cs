using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using SegurancaTrabalho.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientesRepository: IClientes
    {

        protected readonly DataContext _context;
        public ClientesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
            Cliente_Entity obj = await GetById(Id);

            if (obj == null)
            {
                return false;
            }

            try
            {
                _context.Set<Cliente_Entity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<IEnumerable<Cliente_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Cliente_Entity>()
                    .Include(e => e.ClienteColaboradores).ThenInclude(e => e.Colaborador)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cargo)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cliente)
                    .Include(e => e.Funcionario).ThenInclude(e => e.Clientes)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Cliente_Entity>()
                    .Include(e => e.ClienteColaboradores).ThenInclude(e => e.Colaborador)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cargo)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cliente)
                    .Include(e => e.Funcionario).ThenInclude(e => e.Clientes)
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente_Entity> GetCliente(string cliente)
        {
            try
            {
                return await _context.Set<Cliente_Entity>()
                    .Include(e => e.ClienteColaboradores) .ThenInclude(e => e.Colaborador)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cargo)
                    .Include(e => e.ClienteCargos).ThenInclude(e => e.Cliente)
                    .Include(e => e.Funcionario) .ThenInclude(e => e.Clientes)
                    .Where(x => x.Nome == cliente)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente_Entity> Post(Cliente_Entity entity)
        {
            try
            {
                await _context.Set<Cliente_Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
                
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<Cliente_Entity> Put(Cliente_Entity entity)
        {
            Cliente_Entity obj = await GetById(entity.Id);

            try
            {
                if (obj == null)
                {
                    return null;
                }

                obj.Nome = !String.IsNullOrWhiteSpace(entity.Nome) ? entity.Nome : obj.Nome;
                obj.IdEmpresa = !int.IsEvenInteger(entity.IdEmpresa) ? entity.IdEmpresa : obj.IdEmpresa;
                obj.IdFuncionario = !int.IsEvenInteger(entity.IdFuncionario) ? entity.IdFuncionario : obj.IdFuncionario;

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
