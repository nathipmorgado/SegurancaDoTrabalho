using Domain.Entities.Entities;
using SegurancaTrabalho.Domain.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IEmpresa : IGeneric<Empresa_Entity>
    {
        Task<Empresa_Entity> GetEmpresa (string empresa);
    }
}
