using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork.EF
{
	internal class EFRepository<T> : IRepository<T> where T : class
	{
		protected DbContext _dbContext = null;

		internal EFRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(T model)
		{
			_dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
		}

		public void Add(T model)
		{
			_dbContext.Set<T>().Add(model);
		}

		public void Remove(T model)
		{
			_dbContext.Set<T>().Remove(model);
		}

		public T Find(object key)
		{
			return _dbContext.Set<T>().Find(key);
		}

		public IQueryable<T> Query()
		{
			return _dbContext.Set<T>();
		}

		public IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> path) where TProperty : class
		{
			return _dbContext.Set<T>().Include(path);
		}

		public int Count(Expression<Func<T, bool>> path)
		{
			return _dbContext.Set<T>().Count(path);
		}

		public void RemoveRange(IEnumerable<T> range)
		{
			_dbContext.Set<T>().RemoveRange(range);
		}

		public void AddRange(IEnumerable<T> range)
		{
			_dbContext.Set<T>().AddRange(range);
		}
	}
}
