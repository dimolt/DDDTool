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

namespace SugiTool.DistinctData.WinForm.Views
{
    public partial class DistinctDataView : Form
    {
        class KeyData
        {
            public string ShopNo { get; set; }
            public string ChozaiDate { get; set; }
            public string HokenType { get; set; }

            public string UniqueKey
            {
                get => ShopNo + ChozaiDate + HokenType;
            }
        }
        class LineData
        {
            public KeyData Key { get; private set; }
            public string Text { get; set; }

            public LineData(string lineTxt)
            {
                var data = lineTxt.Split(',');

                Key = new KeyData()
                {
                     ShopNo = data[0]
                    ,ChozaiDate = data[1]
                    ,HokenType = data[2]
                };
                Text = lineTxt;
            }
        }

        private const string FILE_NAME = "t_chozaihoshukosei.csv";
        private List<LineData> List = new List<LineData>();

        public DistinctDataView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rootDir = textBox1.Text;
            string targetDir = textBox2.Text;

            if (!File.Exists(Path.Combine(rootDir, FILE_NAME)))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(Path.Combine(rootDir, FILE_NAME)))
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var lineData = new LineData(line);
                int idx = List.FindIndex(x => x.Key.UniqueKey == lineData.Key.UniqueKey);
                if (idx >= 0)
                {
                    List[idx] = lineData;
                }
                else
                {
                    List.Add(lineData);
                }
            }

            //ファイル保存
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            string savePath = Path.Combine(targetDir, FILE_NAME);
            StringBuilder builder = new StringBuilder();
            foreach(var data in List)
            {
                builder.AppendLine(data.Text);
            }
            File.WriteAllText(savePath, builder.ToString());
        }
    }
}
