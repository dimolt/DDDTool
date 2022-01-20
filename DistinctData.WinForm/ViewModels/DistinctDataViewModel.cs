using SugiTool.Domain.Entities;
using SugiTool.Domain.Helper;
using SugiTool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SugiTool.DistinctData.WinForm.ViewModels
{
	public class DistinctDataViewModel
	{
		private IChozaihoshukoseiRepository _chouzaihoushu;

		public DistinctDataViewModel(IChozaihoshukoseiRepository chouzaihoushu)
		{
			_chouzaihoushu = chouzaihoushu;
		}

		public string OutputPath { get; set; } = string.Empty;
		public string InputPath { get; set; } = string.Empty;
		public List<ChozaihoushukoseiEntity> ChozaihoushukoseiList { get; } = new List<ChozaihoushukoseiEntity>();

		public void Read()
		{
			ChozaihoushukoseiList.Clear();
			ChozaihoushukoseiList.AddRange(
				_chouzaihoushu.Read(InputPath)
				);
		}

		public void Save()
		{
			ChozaihoushukoseiList.DistinctList();
			//ファイル保存
			_chouzaihoushu.Write(OutputPath, ChozaihoushukoseiList);
		}
	}
}
