using SugiTool.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiTool.Domain.Entities
{
	public sealed class ChozaihoushukoseiEntity
	{
		private ChozaihoushukoseiData _data;

		public ChozaihoushukoseiEntity(string lineTxt)
		{
			_data = new ChozaihoushukoseiData(lineTxt);
		}
	}
}
