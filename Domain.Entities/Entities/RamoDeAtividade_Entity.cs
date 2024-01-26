using System.Collections.Generic;

namespace Domain.Entities.Entities
{
    public class RamoDeAtividade_Entity 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection <Cliente_Entity> Cliente { get; set; }
        
    }
}
