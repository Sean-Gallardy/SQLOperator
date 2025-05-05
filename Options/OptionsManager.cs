using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;
using SQLOperator.Services;

namespace SQLOperator.Options
{
	public class OptionsManager : SQLOperatorService, IOptionsService
	{
		public IGeneralOptions GeneralOptions
		{
			get
			{
				if(_package == null)
				{
					throw new InvalidOperationException();
				}

				return (IGeneralOptions)_package.GetDialogPage(typeof(OperatorGeneralOptionsPage));
			}
		}
	}
}
