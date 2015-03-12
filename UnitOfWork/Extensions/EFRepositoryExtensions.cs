using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork.EF.Extensions
{
	public interface IRepositoryExtended<T> : IRepository<T>
	{
		IQueryable<T> Query();
		IQueryable<T> Include(string path);
		IQueryable<T> Include(Expression<Func<T, object>> path);
	}

	public static class IRepositoryExtension
	{
		public static IQueryable<T> Query<T>(this IRepository<T> myInterface)
		{
			if (myInterface is IRepositoryExtended<T>)
				return (myInterface as IRepositoryExtended<T>).Query();
			else
			{
				throw new Exception("Query is Unknown");
			}
		}

		public static IQueryable<T> Include<T>(this IRepository<T> myInterface, string path)
		{
			if (myInterface is IRepositoryExtended<T>)
				return (myInterface as IRepositoryExtended<T>).Include(path);
			else
			{
				throw new Exception("Include is Unknown");
			}
		}

		public static IQueryable<T> Include<T>(this IRepository<T> myInterface, Expression<Func<T, object>> path)
		{
			if (myInterface is IRepositoryExtended<T>)
				return (myInterface as IRepositoryExtended<T>).Include(path);
			else
			{
				throw new Exception("Include is Unknown");
			}
		}
	}
}