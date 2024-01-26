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
    public class PermissaoRepository : IPermissao
    {
        protected readonly DataContext _context;
        public PermissaoRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Permissao_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Permissao_Entity>()
                        .Include(p => p.Colaboradores)
                        .ThenInclude ( p=> p.Permissao)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public async Task<Permissao_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Permissao_Entity>()
                    .Where(x => x.Id == Id)
                    .Include(p => p.Colaboradores)
                    .ThenInclude(p => p.Permissao)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Permissao_Entity> GetPermissao(string permissao)
        {
            throw new NotImplementedException();
        }

        public Task<Permissao_Entity> Post(Permissao_Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Permissao_Entity> Put(Permissao_Entity entity)
        {
            throw new NotImplementedException();
        }

    }
}
