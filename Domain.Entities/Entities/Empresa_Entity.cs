using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Entities
{
    public class Empresa_Entity 
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Colaborador_Entity> Colaboradores { get; set; }

    }
}
