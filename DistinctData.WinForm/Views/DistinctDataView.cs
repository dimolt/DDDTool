using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using SugiTool.DistinctData.WinForm.ViewModels;

namespace SugiTool.DistinctData.WinForm.Views
{
    public partial class DistinctDataView : Form
    {
        private DistinctDataViewModel _viewMode
            = new DistinctDataViewModel();

        public DistinctDataView()
        {
            InitializeComponent();

            srcDirTextBox.DataBindings.Add(
                "Text", _viewMode, nameof(_viewMode.InputPath));
            dstDirTextBox.DataBindings.Add(
                "Text", _viewMode, nameof(_viewMode.OutputPath));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _viewMode.Read();
            _viewMode.Distinct();
            _viewMode.Save();
        }
    }
}
