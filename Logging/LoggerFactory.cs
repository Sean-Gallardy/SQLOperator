using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;

namespace SQLOperator.Logging
{
	public static class LoggerFactory
	{
		public static ILogger CreateNewLogger<T>(Package package) where T : ILogger, new()
		{
			ILogger logger = new T();
			((ILoggerCreate)logger).Initialize(package);
			return logger;
		}
	}
}
