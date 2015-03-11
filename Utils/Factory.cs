using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.Utils
{
	public class Factory<T>
	{
		private Func<T> _creator;

		public Factory(Func<T> factory)
		{
			_creator = factory;
		}

		public T Create()
		{
			return _creator();
		}
	}
}