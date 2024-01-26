using Domain.Entities.Entities;
using SegurancaTrabalho.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IColaborador : IGeneric <Colaborador_Entity>
    {
        Task<Colaborador_Entity> GetColaborador(string colaborador, string senha);
    }
}
