using System;

namespace SQLOperator.Logging
{
	public interface ILogger : IDisposable
	{
		void LogTraceMessage(string message);
		void LogError(string message);

	}
}
