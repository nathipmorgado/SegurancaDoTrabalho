using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegurancaTrabalho.BusinessEntities.Entities;

namespace SegurancaTrabalho.Repository.Map
{
    internal sealed class TokenMap : IEntityTypeConfiguration<Token_Entity>
    {
        public void Configure(EntityTypeBuilder<Token_Entity> builder)
        {
            builder.ToTable("Account"); 
        }
    }
}