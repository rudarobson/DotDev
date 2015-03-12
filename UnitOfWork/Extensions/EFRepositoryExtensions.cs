using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork.EF.Extensions
{
	public interface IEFRepositoryExtended<T> : IRepository<T>
	{
		IQueryable<T> Query();
		IQueryable<T> Include(string path);
		IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> path) where TProperty : class;
	}

	public static class IRepositoryExtension
	{
		private const string ExceptionMessage = "Does not implement IEFRepositoryExtended<T>";
		public static IQueryable<T> Query<T>(this IRepository<T> myInterface)
		{
			if (myInterface is IEFRepositoryExtended<T>)
				return (myInterface as IEFRepositoryExtended<T>).Query();
			else
			{
				throw new Exception(ExceptionMessage);
			}
		}

		public static IQueryable<T> Include<T>(this IRepository<T> myInterface, string path)
		{
			if (myInterface is IEFRepositoryExtended<T>)
				return (myInterface as IEFRepositoryExtended<T>).Include(path);
			else
			{
				throw new Exception(ExceptionMessage);
			}
		}

		public static IQueryable<T> Include<T, TProperty>(this IRepository<T> myInterface, Expression<Func<T, TProperty>> path) where TProperty : class
		{
			if (myInterface is IEFRepositoryExtended<T>)
				return (myInterface as IEFRepositoryExtended<T>).Include(path);
			else
			{
				throw new Exception(ExceptionMessage);
			}
		}
	}
}