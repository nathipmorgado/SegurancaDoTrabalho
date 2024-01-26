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
    public class ClienteCargoMap: IEntityTypeConfiguration<Cliente_Cargo_Entity>
    {
        public void Configure(EntityTypeBuilder<Cliente_Cargo_Entity> builder)
        {
            builder.ToTable("cliente_cargo");

            builder.HasKey(cc => new { cc.ClienteId, cc.CargoId });

            builder.HasOne(bc => bc.Cargo).WithMany(b => b.ClienteCargos).HasForeignKey(bc => bc.CargoId);
            builder.HasOne(bc => bc.Cliente).WithMany(b => b.ClienteCargos).HasForeignKey(bc => bc.ClienteId);
        }
    }
}
