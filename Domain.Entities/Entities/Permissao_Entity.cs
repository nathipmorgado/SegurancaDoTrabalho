using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Entities
{
    public class Permissao_Entity
    {
        [Key]
        public int Id { get; set; }
        public string TipoPermissao { get; set; }
        public virtual ICollection<Colaborador_Entity> Colaboradores { get; set; }

    }
}
