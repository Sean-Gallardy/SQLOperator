using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;

namespace SQLOperator.Services
{
	public class SQLOperatorService : IService
	{
		protected Package _package;
		public void Initialize(Package package)
		{
			_package = package;
		}
	}
}
