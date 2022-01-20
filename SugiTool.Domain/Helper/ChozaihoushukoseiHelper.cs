using SugiTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiTool.Domain.Helper
{
	public static class ChozaihoushukoseiHelper
	{
		public static void DistinctList(this List<ChozaihoushukoseiEntity> srcList)
		{
			var distincted = new List<ChozaihoushukoseiEntity>();

			//

			srcList.Clear();
			srcList.AddRange(distincted);
		}
	}
}
