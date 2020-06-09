using Store.Entites;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Implementation.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL.Implementation.DataInit
{
	public static class DataInitializer
	{
		public static void InitData()
		{
			var product = new ProductEntity() { Category = "test", Description = "test", Name = "test", Price = 1000 };
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
