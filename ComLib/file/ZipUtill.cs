using System;
using System.IO;
using System.IO.Compression;
//
using ComLib.log;

namespace ComLib
{
	/// <summary>
	/// ZIP ファイル操作
	/// </summary>
	public class ZipUtil
	{
		#region メンバ変数
		/// <summary>
		/// ロガー
		/// </summary>
		private ILogger vMlog;
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="vIlog">ロガー</param>
		public ZipUtil(ILogger vIlog)
		{
			vMlog = vIlog;
		}
		#endregion

		#region [public]メソッド
		/// <summary>
		/// ファイル作成(中身は空)
		/// </summary>
		/// <param name="srcDir">圧縮ディレクトリ</param>
		/// <param name="dstFile">ZIPファイル</param>
		/// <returns>処理結果</returns>
		public bool ZipDir(string srcDir, string dstFile)
		{
			try
			{
				if (File.Exists(dstFile) == true)
				{
					File.Delete(dstFile);
					//vMlog.Info("既存ZIPファイル削除[{0}]", dstFile);
				}

				ZipFile.CreateFromDirectory(srcDir, dstFile);
				//vMlog.Info("ZIPファイル作成[{0}]→[{1}]", srcDir, dstFile);

				return true;
			}
			catch (Exception ex)
			{
				//vMlog.Error("ZIPファイル[{0}]作成でエラーが発生\n" + ex, dstFile);
				return false;
			}
		}
		#endregion
	}
}		
