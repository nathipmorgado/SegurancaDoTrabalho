using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Map
{
    internal sealed class ClienteColaboradorMap : IEntityTypeConfiguration<Cliente_Colaborador_Entity>
    {
        public void Configure(EntityTypeBuilder<Cliente_Colaborador_Entity> builder)
        {
            builder.ToTable("cliente_colaborador");

            builder.HasKey(cc => new { cc.ClienteId, cc.ColaboradorId });

            builder.HasOne(bc => bc.Colaborador).WithMany(b => b.ClienteColaboradores).HasForeignKey(bc => bc.ColaboradorId);
            builder.HasOne(bc => bc.Cliente).WithMany(b => b.ClienteColaboradores).HasForeignKey(bc => bc.ClienteId);
        }
    }
}

