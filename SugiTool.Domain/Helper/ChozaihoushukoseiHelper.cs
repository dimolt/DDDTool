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
			var tmpList = new List<ChozaihoushukoseiEntity>();
			tmpList.AddRange(srcList);
			srcList.Clear();
			foreach(var entity in tmpList)
			{
				if (!srcList.Any(x => x.Data.Equals(entity.Data)))
				{
					srcList.Add(entity);
				}
			}
		}
	}
}
