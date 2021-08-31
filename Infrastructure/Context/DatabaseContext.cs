using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexto
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options) { }

		public DbSet<AppUser> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }		
	}
}
