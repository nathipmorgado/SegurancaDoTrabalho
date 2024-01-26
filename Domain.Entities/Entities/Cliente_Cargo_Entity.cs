using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entities
{
    public class Cliente_Cargo_Entity
    {
        [Key]
        public int ClienteId { get; set; }
        [Key]
        public int CargoId { get; set; }
        public Cliente_Entity Cliente { get; set; }
        public Cargo_Entity Cargo { get; set; }
      
    }
}
