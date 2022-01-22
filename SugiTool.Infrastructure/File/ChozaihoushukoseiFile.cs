using ComLib;
using SugiTool.Domain.Entities;
using SugiTool.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO ;

namespace SugiTool.Infrastructure.File
{
	public sealed class ChozaihoushukoseiFile : IChozaihoshukoseiRepository
	{
		public List<ChozaihoushukoseiEntity> Read(string path)
		{
			var list = new List<ChozaihoushukoseiEntity>();

			if (!IO.File.Exists(path))
			{
				return list;
			}

			foreach(string line in IO.File.ReadLines(path, StrUtil.ENC_SHIFTJIS))
			{
				list.Add(
					new ChozaihoushukoseiEntity(line)
					);
			}

			return list;
		}

		public bool Write(string path, List<ChozaihoushukoseiEntity> entities)
		{
			try
			{
				//ファイル保存
				if (!IO.Directory.Exists(path))
				{
					IO.Directory.CreateDirectory(path);
				}
				string dstFile = IO.Path.Combine(path, "Result.csv");

				using (var strm = new IO.FileStream(dstFile, IO.FileMode.OpenOrCreate, IO.FileAccess.Write))
				using (var writer = new IO.StreamWriter(strm, StrUtil.ENC_SHIFTJIS))
				{
					foreach(var entity in entities)
					{
						writer.WriteLine(entity.Data.Value);
					}
				}

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
