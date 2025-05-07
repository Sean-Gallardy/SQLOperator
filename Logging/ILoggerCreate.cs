using Microsoft.VisualStudio.Shell;

namespace SQLOperator.Logging
{
	public interface ILoggerCreate
	{
		void Initialize(Package package);
	}
}
