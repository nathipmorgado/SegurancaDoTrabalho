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
    public class RamoDeAtividadeRepository : IRamoDeAtividade
    {
        protected readonly DataContext _context;
        public RamoDeAtividadeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
            RamoDeAtividade_Entity obj = await GetById(Id);

            if (obj == null)
            {
                return false;
            }

            try
            {
                _context.Set<RamoDeAtividade_Entity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<IEnumerable<RamoDeAtividade_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<RamoDeAtividade_Entity>()
                   .Include(u => u.Cliente)
                   .ThenInclude(u => u.RamoDeAtividade)
                   .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RamoDeAtividade_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<RamoDeAtividade_Entity>()
                    
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RamoDeAtividade_Entity> GetRamoDeAtividade(string ramoDeAtividade)
        {
            try
            {
                return await _context.Set<RamoDeAtividade_Entity>()
                    
                    .Where(x => x.Nome == ramoDeAtividade)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<RamoDeAtividade_Entity> Post(RamoDeAtividade_Entity entity)
        {
            try
            {
                await _context.Set<RamoDeAtividade_Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<RamoDeAtividade_Entity> Put (RamoDeAtividade_Entity entity)
        {
            RamoDeAtividade_Entity obj = await GetById(entity.Id);

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
