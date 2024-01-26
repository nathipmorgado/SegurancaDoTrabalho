using Domain.Entities.Entities;
using System.Collections.Generic;

namespace Application.Dto
{
    public class Colaborador_Dto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int PermissaoId { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public int RG { get; set; }
        public double CPF { get; set; }
        public string Endereco { get; set; }
        public int NumeroEndereco { get; set; }
        public string Cidade { get; set; }
        public int CEP { get; set; }
        public int ExclusaoLogica { get; set; }
        
    }
}
