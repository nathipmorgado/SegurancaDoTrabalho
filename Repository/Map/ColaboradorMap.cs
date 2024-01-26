using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Map
{

    internal sealed class ColaboradorMap : IEntityTypeConfiguration<Colaborador_Entity>
    {
        public void Configure(EntityTypeBuilder<Colaborador_Entity> builder)
        {
            builder.ToTable("colaborador");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Usuario)
                   .IsRequired()
                   .HasMaxLength(45);

            builder.HasIndex(u => u.Senha)
                   .IsUnique();
                        
            builder.Property(u => u.Senha)
                   .HasMaxLength(45);

            builder.Property(u => u.PermissaoId)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(u => u.IdEmpresa)
                   .IsRequired()
                   .HasMaxLength(11);

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

            builder.Property(u => u.NumeroEndereco)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.Cidade)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.CEP)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.ExclusaoLogica)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasMany(c => c.ClienteColaboradores)
                   .WithOne(cc => cc.Colaborador)
                   .HasForeignKey(cc => cc.ColaboradorId);

            builder.HasOne(c => c.Permissao)
                  .WithMany(cc => cc.Colaboradores)
                  .HasForeignKey(cc => cc.PermissaoId);

            builder.HasOne(c => c.Empresa)
                  .WithMany(cc => cc.Colaboradores)
                  .HasForeignKey(cc => cc.IdEmpresa);


        }
    }
}
