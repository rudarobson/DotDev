using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork.Extensions
{
	internal interface IRepositoryExtended<T> : IRepository<T>
	{
		void AddRange(IEnumerable<T> range);
		void RemoveRange(IEnumerable<T> range);
		int Count(Expression<Func<T, bool>> path);
	}

	public static class IRepositoryExtension
	{
		public static void AddRange<T>(this IRepository<T> myInterface, IEnumerable<T> range)
		{
			if (myInterface is IRepositoryExtended<T>)
				(myInterface as IRepositoryExtended<T>).AddRange(range);
			else
			{
				throw new Exception("AddRange is Unknown");
			}
		}

		public static void RemoveRange<T>(this IRepository<T> myInterface, IEnumerable<T> range)
		{
			if (myInterface is IRepositoryExtended<T>)
				(myInterface as IRepositoryExtended<T>).RemoveRange(range);
			else
			{
				throw new Exception("RemoveRange is Unknown");
			}
		}

		public static int Count<T>(this IRepository<T> myInterface, Expression<Func<T, bool>> path)
		{
			if (myInterface is IRepositoryExtended<T>)
				return (myInterface as IRepositoryExtended<T>).Count(path);
			else
			{
				throw new Exception("Count is Unknown");
			}
		}
	}
}