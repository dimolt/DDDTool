using ComLib.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiTool.Domain.ValueObjects
{
	public sealed class ChozaihoushukoseiData : ValueObject<ChozaihoushukoseiData>
	{
		public string ShopNo { get; } = string.Empty;
		public string ChozaiDate { get; } = string.Empty;
		public string HokenType { get; } = string.Empty;

		public ChozaihoushukoseiData(string value)
		{
			Value = value;

			if (!string.IsNullOrEmpty(Value))
			{
				var values = value.Split(',');
				ShopNo = values[0];
				ChozaiDate = values[1];
				HokenType = values[2];
			}
		}
		public string Value { get; }

		protected override bool EqualsCore(ChozaihoushukoseiData other)
		{
			return ((ShopNo == other.ShopNo)
				&& (ChozaiDate == other.ChozaiDate)
				&& (HokenType == other.HokenType));
		}
	}
}
