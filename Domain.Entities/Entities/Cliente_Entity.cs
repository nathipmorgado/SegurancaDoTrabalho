using System.Collections.Generic;

namespace Domain.Entities.Entities
{
    public class Cliente_Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEmpresa { get; set; }
        public int IdFuncionario { get; set; }
        public int IdRamoDeAtividade { get; set; }
        public  Funcionario_Entity Funcionario { get; set; }
        public RamoDeAtividade_Entity RamoDeAtividade { get; set; }
        public ICollection<Cliente_Colaborador_Entity> ClienteColaboradores { get; set; }
        public ICollection<Cliente_Cargo_Entity> ClienteCargos { get; set; }
    }
}
