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

		[TestMethod]
		public void シナリオ()
		{
			var chozaihoshuMock = new Mock<IChozaihoshukoseiRepository>();
			chozaihoshuMock.Setup(x => x.Read(TEST_FILE)).Returns(
				new List<ChozaihoushukoseiEntity>
				{
					new ChozaihoushukoseiEntity("")
					, new ChozaihoushukoseiEntity("")
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
			viewModel.ChozaihoushukoseiList.Count.Is(2);
		}
	}
}
