using Application.ViewModels;
using AutoMapper;
using Domain;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = false;
			})
			.AddEntityFrameworkStores<OrdersDbContext>()
			.AddDefaultTokenProviders();

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(bearerOptions =>
			{
				bearerOptions.SaveToken = true;
				bearerOptions.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = key,
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
			});

			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<RegisterUserViewModel, IdentityUser>();
				cfg.CreateMap<IdentityUser, RegisterUserViewModel>();
				cfg.CreateMap<LoginUserViewModel, IdentityUser>();
				cfg.CreateMap<IdentityUser, LoginUserViewModel>();
				cfg.CreateMap<UserViewModel, AppUser>();
				cfg.CreateMap<AppUser, UserViewModel>();
				cfg.CreateMap<ProductViewModel, Product>();
				cfg.CreateMap<Product, ProductViewModel>();
				cfg.CreateMap<OrderViewModel, Order>();
				cfg.CreateMap<Order, OrderViewModel>();
				cfg.CreateMap<OrderItem, OrderItemViewModel>();
				cfg.CreateMap<OrderItemViewModel, OrderItem>();
			});

			IMapper mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			RegisterServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, OrdersDbContext ordersDbContext)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
			}

			app.UseRouting();

			app.UseAuthentication();
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

			ordersDbContext.Database.Migrate();
		}

		private static void RegisterServices(IServiceCollection services)
		{
			DependencyContainer.RegisterServices(services);
		}
	}
}
