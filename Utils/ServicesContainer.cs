using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.Utils
{
	public class ServicesContainer
	{
		private IDictionary<object, object> _servicesDictionary = new Dictionary<object, object>();

		public void Register(object key, object service)
		{
			_servicesDictionary.Add(key, service);
		}

		public void Register<T>(T service)
		{
			_servicesDictionary.Add(typeof(T), service);
		}

		public void Unregister(object key, object service)
		{
			_servicesDictionary.Remove(key);
		}

		public void Unregister<T>(T service)
		{
			_servicesDictionary.Remove(typeof(T));
		}

		public T Resolve<T>()
		{
			return (T)_servicesDictionary[typeof(T)];
		}

		public object Resolve(object key)
		{
			return _servicesDictionary[key];
		}

		public void Reset()
		{
			_servicesDictionary.Clear();
		}
	}
}