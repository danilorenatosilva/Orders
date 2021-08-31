using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.Servicos;
using DominioCleanArch.Interfaces;
using InfraCleanArch.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace InfraCleanArch
{
	public class DependencyContainer
	{
        public static void RegisterServices(IServiceCollection services)
        { 
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<ICategoriaServico, CategoriaServico>();

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        }
    }
}
