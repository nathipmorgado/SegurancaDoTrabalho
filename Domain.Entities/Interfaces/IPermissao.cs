using Domain.Entities.Entities;
using SegurancaTrabalho.Domain.Entities.Interfaces;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IPermissao : IGeneric<Permissao_Entity>
    {
        Task<Permissao_Entity> GetPermissao (string permissao);
    }
}
