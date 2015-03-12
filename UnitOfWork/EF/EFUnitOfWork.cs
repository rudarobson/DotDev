using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork.EF
{
	public partial class EFUnitOfWork : UnitOfWork,IDisposable
	{
		private DbContext _context;
		
		public EFUnitOfWork(DbContext context){
			_context = context;
		}

		public override IRepository<T> Resolve<T>()
		{
			if (IRepositoryDictionary[typeof(T)] == null)
				IRepositoryDictionary[typeof(T)] = new EFRepository<T>(_context);

			return (IRepository<T>) IRepositoryDictionary[typeof(T)];
		}

		public override void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			if (_context != null)
				_context.Dispose();
		}
	}
}
