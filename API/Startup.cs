using AplicacaoCleanArch.ViewModels;
using AutoMapper;
using DominioCleanArch;
using InfraCleanArch;
using InfraCleanArch.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

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
			
			services.AddDbContext<DaniloRenatoCommerceDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DaniloRenatoCommerceConnectionString"));
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
			});

			var config = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.CreateMap<CategoriaViewModel, Categoria>();
				cfg.CreateMap<Categoria, CategoriaViewModel>();
				cfg.CreateMap<ProdutoViewModel, Produto>();
				cfg.CreateMap<Produto, ProdutoViewModel>();
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
