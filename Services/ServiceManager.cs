using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using SQLOperator.Options;

namespace SQLOperator.Services
{
	public class ServiceManager : IServiceManager
	{
		private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
		private static readonly ServiceManager _instance = new ServiceManager();

		public static ServiceManager Instance { get { return _instance; } }

		public ServiceManager()
		{
		}

		public void RegisterService<T>(T service)
		{
			if(!_services.ContainsKey(typeof(T)))
			{
				_services.Add(typeof(T), (IService)service);
			}
		}

		public T GetService<T>()
		{
			if(_services.ContainsKey(typeof(T)))
			{
				return (T)_services[typeof(T)];
			}

			throw new KeyNotFoundException();
		}
	}
}
