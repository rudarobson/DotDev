using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork
{
	public partial interface IRepository<T>
	{
		void Update(T model);
		void Add(T model);
		void Remove(T model);
		T Find(object key);
	}
}

