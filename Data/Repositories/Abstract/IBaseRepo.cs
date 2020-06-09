﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Abstract
{
	public interface IBaseRepo<T> : IDisposable
	{
		int Add(T entity);
		int AddRandge(IList<T> entites);
		int Save(T entite);
		int Delete(T entity);
		T GetOne(int? Id);
		IQueryable<T> GetAll();
		void Dispose();
	}
}
