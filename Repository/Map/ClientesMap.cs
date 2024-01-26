using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Map
{
    internal sealed class ClientesMap : IEntityTypeConfiguration<Cliente_Entity>
    {
        public void Configure(EntityTypeBuilder<Cliente_Entity> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.IdEmpresa) 
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(x => x.IdFuncionario)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(x => x.IdRamoDeAtividade)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.HasMany(c => c.ClienteColaboradores)
                  .WithOne(cc => cc.Cliente)
                  .HasForeignKey(cc => cc.ClienteId);

            builder.HasOne(x => x.Funcionario)
                   .WithMany(x => x.Clientes)
                   .HasForeignKey(x => x.IdFuncionario);


            builder.HasMany(c => c.ClienteCargos)
                  .WithOne(cc => cc.Cliente)
                  .HasForeignKey(cc => cc.ClienteId);


            builder.HasOne(x => x.RamoDeAtividade)
                    .WithMany(x => x.Cliente)
                    .HasForeignKey(x => x.IdRamoDeAtividade);

            
        }
    }
}
