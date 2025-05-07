using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLOperator.Logging;

namespace SQLOperator.Services
{
	public interface ILoggingService
	{
		ILogger GetDefaultLogger();
		void SetDefaultLogger(ILogger Logger);

		void LogTrace(string message);
		void LogError(string message);
		
	}
}
