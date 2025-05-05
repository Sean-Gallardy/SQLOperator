using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLOperator.Options;

namespace SQLOperator.Services
{
	public interface IOptionsService
	{
		IGeneralOptions GeneralOptions { get; }
	}
}
