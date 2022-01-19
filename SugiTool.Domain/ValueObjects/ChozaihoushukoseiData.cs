using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiTool.Domain.ValueObjects
{
	public sealed class ChozaihoushukoseiData
	{
		public ChozaihoushukoseiData(string value)
		{
			Value = value;
		}
		public string Value { get; }
	}
}
