using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLOperator.Services;

namespace SQLOperator.Logging
{
	public class LoggingManager : SQLOperatorService, ILoggingService
	{
		public ILogger Logger
		{
			get;
			private set;
		}

		public ILogger GetDefaultLogger()
		{
			return Logger;
		}

		public void SetDefaultLogger(ILogger Logger)
		{
			this.Logger = Logger;
		}

		public void LogTrace(string message)
		{
			Logger.LogTraceMessage(message);
		}

		public void LogError(string message)
		{
			Logger.LogError(message);
		}
	}
}
