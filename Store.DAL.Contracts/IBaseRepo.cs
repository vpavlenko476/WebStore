﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Contracts
{
	public interface IBaseRepo<T> : IDisposable
	{
		Task<int> Add(T entity);
		Task<int> Add(IList<T> entites);
		Task<int> Update(T entite);
		Task<int> Delete(T entity);
		Task<T> GetOne(int? Id);
		IQueryable<T> GetSome(Expression<Func<T, bool>> where);
		IQueryable<T> GetAll();
		void Dispose();
	}
}