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
    public class EmpresaRepository : IEmpresa
    {
        protected readonly DataContext _context;
        public EmpresaRepository (DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Empresa_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Empresa_Entity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Empresa_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Empresa_Entity>()
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Empresa_Entity> GetEmpresa(string empresa)
        {
            try
            {
                return await _context.Set<Empresa_Entity>()
                    .Where(x => x.Nome == empresa)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Empresa_Entity> Post(Empresa_Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa_Entity> Put(Empresa_Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
