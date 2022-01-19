using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using log4net;

namespace ComLib
{
    public class CsvReader : IDisposable
    {
        private TextFieldParser parser = null;
        public ILog Log
        {
            get;
            set;
        } = null;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath"></param>
        public CsvReader(string filePath)
        {
            if (!File.Exists(filePath)) return;
            parser = new TextFieldParser(filePath, StrUtil.ENC_SHIFTJIS);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;
        }
        public CsvReader(StreamReader reader)
        {
            parser = new TextFieldParser(reader);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;
        }
        public void Dispose()
        {
            if (parser != null)
            {
                parser.Dispose();
            }
        }

        public bool IsEnd
        {
            get
            {
                if (parser == null) return true;
                return parser.EndOfData; 
            }
        }

        public string[] Read()
        {
            try
            {
                return parser.ReadFields();
            }
            catch(Exception ex)
            {

                if (Log != null) { Log.Error("CSVデータ読込失敗：" + ex); }
                return new string[] { };
            }
        }

    }
}
