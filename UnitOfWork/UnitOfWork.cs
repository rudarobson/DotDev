using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotDev.UnitOfWork.Extensions;

namespace DotDev.UnitOfWork
{
	public abstract class UnitOfWork
	{
		protected IDictionary<Type, object> IRepositoryDictionary = new Dictionary<Type, object>();
		public abstract IRepository<T> Resolve<T>() where T : class;
		public abstract void SaveChanges();
	}
}
