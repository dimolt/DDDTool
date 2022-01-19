using SugiTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugiTool.Domain.Repositories
{
	public interface IChozaihoshukoseiRepository
	{
		List<ChozaihoushukoseiEntity> Read(string path);
		bool Write(string path, List<ChozaihoushukoseiEntity> entities);
	}
}
