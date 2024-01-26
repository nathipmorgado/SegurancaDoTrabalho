using SegurancaTrabalho.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SegurancaTrabalho.Repository.Context
{
    //ContextFactory para acessar o oracle
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //MySQL NatyVitor ---> pesquisar (ver o curso)
            
            //Oracle
            //var connectionString = "User Id=system;Password=sql2008;Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = NOTE_EDERSON)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = XE)))";
            //SqlServer
            var connectionString = "Server=localhost;Port=3306;DataBase=dbNET5atualizado;Uid=root;Pwd=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            //vari precisar UseMysql
            return new DataContext(optionsBuilder.Options);
        }
    }
}
