using Microsoft.Extensions.DependencyInjection;
using Domain.Entities.Interfaces;
using Domain.Service;

namespace SegurancaTrabalho.DataAcessLayer.CrosCutting
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddTransient<IEmpresa, EmpresaService>();
            serviceCollection.AddTransient<IColaborador, ColaboradorService>();
            serviceCollection.AddTransient<IPermissao, PermissaoService>();
            serviceCollection.AddTransient<IClientes, ClientesService>();
            serviceCollection.AddTransient<ICargo, CargoService>();
            serviceCollection.AddTransient<IFuncionario, FuncionarioService>();
            serviceCollection.AddTransient<IRamoDeAtividade, RamoDeAtividadeService>();

        }
    }
}


