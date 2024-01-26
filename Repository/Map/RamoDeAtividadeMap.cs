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
    internal sealed class RamoDeAtividadeMap : IEntityTypeConfiguration<RamoDeAtividade_Entity>
    {
        public void Configure(EntityTypeBuilder<RamoDeAtividade_Entity> builder)
        {
            builder.ToTable("ramo_atividade");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasMany(u => u.Cliente)
                   .WithOne(u => u.RamoDeAtividade)
                   .HasForeignKey(u => u.IdRamoDeAtividade);
        }
    }
}
