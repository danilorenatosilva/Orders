using Application.ViewModels;
using AutoMapper;
using Domain;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			
			services.AddDbContext<OrdersDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("OrdersConnectionString"));
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
			});

			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<RegisterUserViewModel, AppUser>();
				cfg.CreateMap<AppUser, RegisterUserViewModel>();
				cfg.CreateMap<LoginUserViewModel, AppUser>();
				cfg.CreateMap<AppUser, LoginUserViewModel>();
				cfg.CreateMap<ProductViewModel, Product>();
				cfg.CreateMap<Product, ProductViewModel>();
				cfg.CreateMap<OrderViewModel, Order>();
				cfg.CreateMap<Order, OrderViewModel>();
			});

			IMapper mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			RegisterServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCors(config =>
			{
				config.AllowAnyOrigin();
				config.AllowAnyHeader();
				config.AllowAnyMethod();
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		private static void RegisterServices(IServiceCollection services)
		{
			DependencyContainer.RegisterServices(services);
		}
	}
}
