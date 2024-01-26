using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public class Cargo_Entity
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string Nome { get; set; }
        public ICollection<Funcionario_Entity> Funcionarios { get; set; }
        public ICollection<Cliente_Cargo_Entity> ClienteCargos { get; set; }

    }
}
