using Domain.Entities.Entities;
using System.Collections.Generic;

namespace Application.Dto
{
    public class Login_Dto
    {
        public Colaborador_Dto colaborador { get; set; }
        public ICollection<Cliente_Dto> clientes { get; set; }
        public Permissao_Dto  permissao { get; set; }
        public Empresa_Dto empresa { get; set; }
    }
}
