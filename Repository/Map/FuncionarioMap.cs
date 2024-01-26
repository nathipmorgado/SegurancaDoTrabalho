using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Map
{
    internal sealed class FuncionarioMap : IEntityTypeConfiguration<Funcionario_Entity>
    {
        public void Configure(EntityTypeBuilder<Funcionario_Entity> builder)
        {
            builder.ToTable("funcionario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.RG)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(u => u.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(u => u.Endereco)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.IdCargo)
                   .IsRequired()
                   .HasMaxLength(11);


            builder.HasMany(x => x.Clientes)
                   .WithOne(x => x.Funcionario)
                   .HasForeignKey(x => x.IdFuncionario);

        }
    }
}