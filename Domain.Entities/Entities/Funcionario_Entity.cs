using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Entities
{
    public class Funcionario_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int RG { get; set; }
        public double CPF { get; set; }
        public string Endereco { get; set; }
        public int IdCargo { get; set; }
        public Cargo_Entity Cargo { get; set; }
        public ICollection<Cliente_Entity> Clientes { get; set;}

    }
}
