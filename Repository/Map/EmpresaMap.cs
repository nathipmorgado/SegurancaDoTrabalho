using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegurancaTrabalho.Domain.Entities.Entities;

namespace Repository.Map
{
    internal sealed class EmpresaMap : IEntityTypeConfiguration<Empresa_Entity>
    {
        public void Configure(EntityTypeBuilder<Empresa_Entity> builder)
        {
            builder.ToTable("empresa");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasMany(c => c.Colaboradores)
                   .WithOne(cc => cc.Empresa)
                   .HasForeignKey(cc => cc.IdEmpresa);

        }
    }
}

