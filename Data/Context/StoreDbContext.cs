using Microsoft.EntityFrameworkCore;
using Entites;

namespace Data.Context
{
	public class StoreDbContext: DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }		
		public DbSet<Product> Products { get; set; }
	}
}
