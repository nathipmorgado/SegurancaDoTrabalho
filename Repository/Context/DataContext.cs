using SegurancaTrabalho.Repository.Map;
using Microsoft.EntityFrameworkCore;
using Repository.Map;
using Domain.Entities.Entities;

namespace SegurancaTrabalho.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                    : base(options) { }



        public DbSet<Empresa_Entity> Empresa { get; set; }
        public DbSet<Colaborador_Entity> Colaborador { get; set; }
        public DbSet<Permissao_Entity> Permissao { get; set; }
        public DbSet<Cliente_Entity> Clientes { get; set; }
        public DbSet<Cliente_Colaborador_Entity> Cliente_Colaborador { get; set; }
        public DbSet<Cargo_Entity> Cargo { get; set; }
        public DbSet<Cliente_Cargo_Entity> Cliente_Cargo { get; set; }
        public DbSet<Funcionario_Entity> Funcionario { get; set; }
        public DbSet<RamoDeAtividade_Entity> RamoDeAtividade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TokenMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new ClientesMap());
            modelBuilder.ApplyConfiguration(new ClienteColaboradorMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new ClienteCargoMap()); 
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new RamoDeAtividadeMap());
        }
    }
}
