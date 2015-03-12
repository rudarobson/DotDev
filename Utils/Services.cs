using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotDev.Utils
{
	public static class Services
	{
		private static IDictionary<object, object> _servicesDictionary = new Dictionary<object, object>();

		public static void Register(object key, object service)
		{
			_servicesDictionary.Add(key, service);
		}

		public static void Register<T>(T service)
		{
			_servicesDictionary.Add(typeof(T), service);
		}

		public static void Unregister(object key)
		{
			_servicesDictionary.Remove(key);
		}

		public static void Unregister<T>()
		{
			_servicesDictionary.Remove(typeof(T));
		}

		public static T Resolve<T>()
		{
			return (T)_servicesDictionary[typeof(T)];
		}

		public static object Resolve(object key)
		{
			return _servicesDictionary[key];
		}

		public static void Reset()
		{
			_servicesDictionary.Clear();
		}
	}
}