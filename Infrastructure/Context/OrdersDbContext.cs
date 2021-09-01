using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
	public class OrdersDbContext : IdentityDbContext
	{
		public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
