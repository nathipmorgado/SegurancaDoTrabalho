using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Map
{

    internal sealed class CargoMap : IEntityTypeConfiguration<Cargo_Entity>
    {
        public void Configure(EntityTypeBuilder<Cargo_Entity> builder)
        {
            builder.ToTable("cargo");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasMany(x => x.Funcionarios)
                   .WithOne(x => x.Cargo)
                   .HasForeignKey(x => x.IdCargo);
           
        }
    }
}
