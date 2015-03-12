using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.UnitOfWork.EF
{
	public partial class EFUnitOfWork : IDisposable,IUnitOfWork
	{
		protected IDictionary<Type, object> IRepositoryDictionary = new Dictionary<Type, object>();

		private DbContext _context;
		
		public EFUnitOfWork(DbContext context){
			_context = context;
		}

		public IRepository<T> Resolve<T>() where T : class
		{
			if (IRepositoryDictionary[typeof(T)] == null)
				IRepositoryDictionary[typeof(T)] = new EFRepository<T>(_context);

			return (IRepository<T>) IRepositoryDictionary[typeof(T)];
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		private bool _isDisposed = false;
		public void Dispose()
		{
			if (!_isDisposed)
			{
				if (_context != null)
					_context.Dispose();

				IRepositoryDictionary.Clear();
				IRepositoryDictionary = null;
				GC.SuppressFinalize(this);
				_isDisposed = true;
			}
		}
	}
}
