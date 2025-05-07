using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;

namespace SQLOperator.Logging
{
	public class OutputWindowLogger : ILogger, ILoggerCreate
	{
		private static readonly Guid _OutputWindowPaneGUID = new Guid("d6520476-43c0-4d28-90c2-58ebc59fcfcd");
		private static readonly string _OutputWindowName = "SQLOperatorOutputWindowPane";
		private IVsOutputWindowPane _WindowPane;
		private IVsOutputWindow _OutputWindow;
		public OutputWindowLogger()
		{
		}

		public void Initialize(Package package)
		{
			IVsOutputWindow sqlOperatorOutputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
			if(sqlOperatorOutputWindow == null)
			{
				throw new NullReferenceException();
			}

			_OutputWindow = sqlOperatorOutputWindow;
			IVsOutputWindowPane sqlOperatorOutputPane;
			Guid paneGuid = _OutputWindowPaneGUID;

			sqlOperatorOutputWindow.GetPane(paneGuid, out sqlOperatorOutputPane);
			if(sqlOperatorOutputPane == null)
			{
				sqlOperatorOutputWindow.CreatePane(paneGuid, _OutputWindowName, Convert.ToInt32(true), Convert.ToInt32(false));
			}

			sqlOperatorOutputWindow.GetPane(paneGuid, out sqlOperatorOutputPane);

			_WindowPane = sqlOperatorOutputPane;
			_WindowPane.Activate();
		}

		public void LogError(string message)
		{
			_WindowPane.OutputString($"Error: {message}");
		}

		public void LogTraceMessage(string message)
		{
			_WindowPane.OutputString($"Trace: {message}");
		}

		public void Dispose()
		{
			if(_WindowPane != null)
			{
				_OutputWindow.DeletePane(_OutputWindowPaneGUID);
			}
		}
	}
}
