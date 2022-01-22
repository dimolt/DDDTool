using SugiTool.DistinctData.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using SugiTool.Domain.Repositories;
using System.Collections.Generic;
using SugiTool.Domain.Entities;

namespace SugiTool.DistinctDataTest.Tests
{
	[TestClass]
	public class DistinctDataViewModelTest
	{
		private readonly string TEST_FILE = @"D:\Sugi\作成tool\SugiTool_DDD\Test\Test.CSV";
		private readonly string RESULT_FILE = @"D:\Sugi\作成tool\SugiTool_DDD\Test\Result.CSV";

		[TestMethod]
		public void シナリオ()
		{
			var chozaihoshuMock = new Mock<IChozaihoshukoseiRepository>();
			chozaihoshuMock.Setup(x => x.Read(TEST_FILE)).Returns(
				new List<ChozaihoushukoseiEntity>
				{
					new ChozaihoushukoseiEntity("1,2,3")
					, new ChozaihoushukoseiEntity("1,2,3,4")
					, new ChozaihoushukoseiEntity("1,0,1,1,2")
					, new ChozaihoushukoseiEntity("1,0,2,1,2")
				}
			);

			var viewModel = new DistinctDataViewModel(
				chozaihoshuMock.Object);

			//初期値
			viewModel.InputPath.Is("");
			viewModel.OutputPath.Is("");
			viewModel.ChozaihoushukoseiList.Count.Is(0);

			//ファイル読込
			viewModel.InputPath = TEST_FILE;
			viewModel.Read();
			viewModel.ChozaihoushukoseiList.Count.Is(4);

			//一意にまとめる
			viewModel.Distinct();
			viewModel.ChozaihoushukoseiList.Count.Is(3);

			//ファイル保存
			viewModel.OutputPath = RESULT_FILE;
			viewModel.Save();
		}
	}
}
