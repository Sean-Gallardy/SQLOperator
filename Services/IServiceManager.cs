using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;

namespace SQLOperator.Services
{
	public interface IServiceManager
	{
		void RegisterService<T>(T serviceType);

		T GetService<T>();
	}
}
