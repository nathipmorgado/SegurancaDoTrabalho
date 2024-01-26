using Domain.Entities.Entities;
using System.Collections.Generic;

namespace Application.Dto
{
    public class Cliente_Dto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEmpresa { get; set; }
        public int IdFuncionario { get; set; }
        public int IdRamoDeAtividade { get; set; }

    }
}
