using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Map
{
    internal sealed class ClienteMap : IEntityTypeConfiguration<Cliente_Entity>
    {
        public void Configure(EntityTypeBuilder<Cliente_Entity> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                  .IsRequired()
                  .HasMaxLength(255);



        }
    }
}
