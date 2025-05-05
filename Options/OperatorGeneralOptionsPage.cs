using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;

namespace SQLOperator.Options
{
	public class OperatorGeneralOptionsPage : DialogPage, IGeneralOptions
	{

		[Category("General")]
		[DisplayName("Database to store scripts.")]
		[Description("Create and store scripts in this database, typically TempDB or a DBA database.")]
		public string Database_To_Use_For_Scripts { get; set; } = "TempDB";
	}
}
