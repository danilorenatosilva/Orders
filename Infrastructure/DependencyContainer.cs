using Application.Interfaces;
using Application.Services;
using Application.Servicos;
using Domain.Interfaces;
using Dominio.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public class DependencyContainer
	{
        public static void RegisterServices(IServiceCollection services)
        { 
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();            
        }
    }
}
