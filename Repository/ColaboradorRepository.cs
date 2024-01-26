using Domain.Entities.Entities;
using Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using SegurancaTrabalho.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Repository
{
    public class ColaboradorRepository : IColaborador
    {
        protected readonly DataContext _context;
        public ColaboradorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
            Colaborador_Entity obj = await GetById(Id);

            if (obj == null)
            {
                return false;
            }

            try
            {
                _context.Set<Colaborador_Entity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<IEnumerable<Colaborador_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Colaborador_Entity>()
                    .Include(e => e.ClienteColaboradores)
                    .ThenInclude(e => e.Cliente)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Colaborador_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Colaborador_Entity>()
                    .Include(e => e.ClienteColaboradores)
                    .ThenInclude(e => e.Cliente)
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Colaborador_Entity> GetColaborador(string colaborador, string senha)
        {
            try
            {
                return await _context.Set<Colaborador_Entity>()

                   .Include(e => e.ClienteColaboradores)
                   .ThenInclude(e => e.Cliente)
                   .Include(e => e.Permissao)
                   .Include(e => e.Empresa)
                   .Where(x => x.Usuario == colaborador && x.Senha == senha)
                   .SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Colaborador_Entity> Post(Colaborador_Entity entity)
        {
            try
            { 
                await _context.Set<Colaborador_Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<Colaborador_Entity> Put(Colaborador_Entity entity)
        {
            Colaborador_Entity obj = await GetById(entity.Id);

            try
            {
                if (obj == null)
                {
                    return null;
                }

                obj.Usuario = !String.IsNullOrWhiteSpace(entity.Usuario) ? entity.Usuario : obj.Usuario;
                obj.Senha = !String.IsNullOrWhiteSpace(entity.Senha) ? entity.Senha : obj.Senha;
                obj.PermissaoId = !int.IsEvenInteger(entity.PermissaoId) ? entity.PermissaoId : obj.PermissaoId;
                obj.IdEmpresa = !int.IsEvenInteger(entity.IdEmpresa) ? entity.IdEmpresa : obj.IdEmpresa;
                obj.Nome = !String.IsNullOrWhiteSpace(entity.Nome) ? entity.Nome: obj.Nome;
                obj.RG = !int.IsEvenInteger(entity.RG) ? entity.RG : obj.RG;
                obj.CPF = !double.IsEvenInteger(entity.CPF) ? entity.CPF : obj.CPF;
                obj.Endereco = !String.IsNullOrWhiteSpace(entity.Endereco) ? entity.Endereco : obj.Endereco;
                obj.NumeroEndereco = !int.IsEvenInteger(entity.NumeroEndereco) ? entity.NumeroEndereco : obj.NumeroEndereco;
                obj.Cidade = !String.IsNullOrWhiteSpace(entity.Cidade) ? entity.Cidade: obj.Cidade;
                obj.CEP = !int.IsEvenInteger(entity.CEP) ? entity.CEP : obj.CEP;
                obj.ExclusaoLogica = !int.IsEvenInteger(entity.ExclusaoLogica) ? entity.ExclusaoLogica : obj.ExclusaoLogica;

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

