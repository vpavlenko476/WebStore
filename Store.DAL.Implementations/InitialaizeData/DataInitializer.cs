using Store.DAL.Implementations.Context;
using Entites;
using Microsoft.EntityFrameworkCore;

namespace Store.DAL.Implementations.InitialaizeData
{
	public static class DataInitializer
	{
		public static void InitData()
		{
			var product = new Product() { Category = "test", Description = "test", Name = "test", Price = 1000 };
			var context = new StoreDbContext();
			context.Products.Add(product);
			context.SaveChanges();
		}

		/// <summary>
		/// Удаление и восстановление БД начальными значениями
		/// </summary>		
		public static void RecreateDatabase(StoreDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.Migrate();
		}
	}
}
