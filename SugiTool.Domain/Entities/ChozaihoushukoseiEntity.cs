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
		public ChozaihoushukoseiData Data { get; }

		public ChozaihoushukoseiEntity(string lineTxt)
		{
			Data = new ChozaihoushukoseiData(lineTxt);
		}
	}
}
