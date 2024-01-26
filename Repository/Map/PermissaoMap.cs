using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Map
{
    internal sealed class PermissaoMap : IEntityTypeConfiguration<Permissao_Entity>
    {
        public void Configure(EntityTypeBuilder<Permissao_Entity> builder)
        {
            builder.ToTable("permissao");

            builder.HasKey(u => u.Id);
                   
            builder.Property(u => u.TipoPermissao)
                   .IsRequired()
                   .HasMaxLength(45);
                        
            builder.HasMany(c => c.Colaboradores)
                   .WithOne(cc => cc.Permissao)
                   .HasForeignKey(cc => cc.PermissaoId);


        }
    }
}
