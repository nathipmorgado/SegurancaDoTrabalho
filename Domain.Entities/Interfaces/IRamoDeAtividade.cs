using Domain.Entities.Entities;
using SegurancaTrabalho.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IRamoDeAtividade : IGeneric<RamoDeAtividade_Entity>
    {
        Task<RamoDeAtividade_Entity> GetRamoDeAtividade (string ramoDeAtividade);
    }
}
