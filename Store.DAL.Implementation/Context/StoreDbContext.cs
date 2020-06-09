using Store.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL.Implementation.Context
{
	public class StoreDbContext : DbContext
	{
		internal StoreDbContext() { }
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
		public DbSet<ProductEntity> Products { get; set; }

		/// <summary>
		/// Выполняется если вызван конструктор без параметров
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = @"server=(localdb)\MSSQLLocalDB;Database=Store;integrated security=True;MultipleActiveResultSets=true;App=EntityFramework";
				optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
			}
		}

		public string GetTableName(Type type)
		{
			return Model.FindEntityType(type).DisplayName();
		}
	}
}
