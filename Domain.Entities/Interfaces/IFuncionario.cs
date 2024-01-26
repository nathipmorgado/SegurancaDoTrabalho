using Domain.Entities.Entities;
using SegurancaTrabalho.Domain.Entities.Interfaces;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IFuncionario : IGeneric<Funcionario_Entity>
    {
        Task<Funcionario_Entity> GetFuncionario(string funcionario);
    }
}
