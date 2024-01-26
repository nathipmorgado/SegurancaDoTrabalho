using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entities
{
    public class Colaborador_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int PermissaoId { get; set; }
        public int IdEmpresa{ get; set; }
        public string Nome { get; set; }
        public int RG { get; set; }
        public double CPF { get; set; }
        public string Endereco { get; set; }
        public int NumeroEndereco { get; set; }
        public string Cidade { get; set; }
        public int CEP { get; set; }
        public int ExclusaoLogica { get; set; }

        //ligação 1 para 1
        public Permissao_Entity Permissao { get; set; }
        public Empresa_Entity Empresa { get; set; }
        public virtual ICollection<Cliente_Colaborador_Entity> ClienteColaboradores { get; set; }
        
    }
}
