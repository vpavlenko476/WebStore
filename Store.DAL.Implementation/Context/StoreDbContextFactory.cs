using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Store.DAL.Implementation.Context
{
	class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
	{
		public StoreDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
			var connectionString =
					@"server=(localdb)\MSSQLLocalDB;Database=Store;integrated security=True;MultipleActiveResultSets=true;App=EntityFramework";
			optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
			return new StoreDbContext(optionsBuilder.Options);
		}
	}
}
