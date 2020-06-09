using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using Entites.Abstract;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositories
{
	/// <summary>
	/// CRUD Repository
	/// </summary>
	/// <typeparam name="T">EntityModel</typeparam>
	public class BaseRepo<T> : IBaseRepo<T>
		where T : BaseEntity, new()
	{
		private StoreDbContext _db { get; }
		private readonly DbSet<T> _table;
		protected StoreDbContext Context => _db;
		public BaseRepo(StoreDbContext context)
		{
			if (context == null) throw new ArgumentNullException("Null DbContext");
			_db = context;
			_table = _db.Set<T>();
		}
		public int Add(T entity)
		{
			_table.Add(entity);
			return _db.SaveChanges();
		}

		public int AddRandge(IList<T> entites)
		{
			_table.AddRange(entites);
			return _db.SaveChanges();
		}

		public int Delete(T entity)
		{
			var _entity = _table.Find(entity.Id);
			_db.Entry(_entity).State = EntityState.Deleted;
			return _db.SaveChanges();
		}

		public IQueryable<T> GetAll()
		{
			return _table;
		}

		public T GetOne(int? Id)
		{
			return _table.Find(Id);
		}

		public int Save(T entity)
		{
			var _entity = _table.Find(entity.Id);
			_db.Entry(_entity).CurrentValues.SetValues(entity);
			return _db.SaveChanges();
		}
		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
