using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public class Cliente_Colaborador_Entity
    {
        [Key]
        public int ClienteId { get; set; }
        [Key]
        public int ColaboradorId { get; set; }
        public Cliente_Entity Cliente { get; set; }
        public Colaborador_Entity Colaborador { get; set; }
    }
}
