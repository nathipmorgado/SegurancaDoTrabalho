using Domain.Entities.Entities;
using SegurancaTrabalho.Domain.Entities.Interfaces;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface ICliente : IGeneric<Cliente_Entity>
    {
        Task<Cliente_Entity> GetCliente(string cliente);
    }
}
