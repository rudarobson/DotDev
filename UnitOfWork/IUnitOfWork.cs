using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork
{
	public partial interface IUnitOfWork
	{
		IRepository<T> Resolve<T>() where T : class;
		void SaveChanges();
	}
}
