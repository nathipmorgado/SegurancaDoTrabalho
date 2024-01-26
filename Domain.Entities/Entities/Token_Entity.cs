using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SegurancaTrabalho.Domain.Entities.Entities;

namespace SegurancaTrabalho.BusinessEntities.Entities
{
    public class Token_Entity : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        public string key { get; set; }
        public string tipoPermissao { get; set; }
    }
}
