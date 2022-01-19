using System;
using System.Net;
using System.Runtime.InteropServices;
//
using ComLib.log;

namespace ComLib
{
	/// <summary>
	/// ネットワーク ユーティリティ
	/// </summary>
	public static class NetWork
	{
		//win32dll インポート
		[DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
		private static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool fForce);

		[DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
		private static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags);

		[StructLayout(LayoutKind.Sequential)]
		private struct NETRESOURCE
		{
			public int dwScope;//列挙の範囲
			public int dwType;//リソースタイプ
			public int dwDisplayType;//表示オブジェクト
			public int dwUsage;//リソースの使用方法
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpLocalName;//ローカルデバイス名。使わないならNULL。
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpRemoteName;//リモートネットワーク名。使わないならNULL
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpComment;//ネットワーク内の提供者に提供された文字列
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpProvider;//リソースを所有しているプロバイダ名
		}

		#region メンバ
		/// <summary>
		/// ロガー
		/// </summary>
		private static ILogger logger = null;
		#endregion

		#region プロパティ
		/// <summary>
		/// 端末名
		/// </summary>
		public static string HostName
		{
			private set;
			get;
		}
		/// <summary>
		/// IPアドレス
		/// </summary>
		public static string IpAddress
		{
			private set;
			get;
		}
		#endregion

		#region [public]メソッド
		/// <summary>
		/// 初期化
		/// </summary>
		/// <remarks>使用前に必ず呼ぶこと</remarks>
		public static void Initailize()
		{
			HostName = Dns.GetHostName();

			IpAddress = "";
			foreach (IPAddress address in Dns.GetHostAddresses(HostName))
			{
				if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					IpAddress = address.ToString();
					break;
				}
			}
		}
		public static void Initailize(ILogger _logger)
		{
			Initailize();
			logger = _logger;
		}

		/// <summary>
		/// ネットワーク切断
		/// </summary>
		/// <param name="networkPath">ネットワークパス</param>
		public static void DisConnect(string networkPath)
		{
			try
			{
				WNetCancelConnection2(networkPath, 0, true);
			}
			catch (Exception ex)
			{
				logger.Warn("ネットワーク切断でエラーが発生\n" + ex);
			}
		}

		/// <summary>
		/// ネットワーク接続
		/// </summary>
		/// <param name="networkPath">ネットワークパス</param>
		/// <param name="user">ユーザ</param>
		/// <param name="pwd">パスワード</param>
		/// <returns></returns>
		public static bool Connect(string networkPaht, string user, string pwd)
		{
			try
			{
				//接続情報 設定
				NETRESOURCE netResource = new NETRESOURCE();
				netResource.dwScope = 0;
				netResource.dwType = 1;
				netResource.dwDisplayType = 0;
				netResource.dwUsage = 0;
				netResource.lpLocalName = "";
				netResource.lpRemoteName = networkPaht;
				netResource.lpProvider = "";

				logger.Info("ネットワーク接続 パス[{0}] USER[{1}] PWD[{2}]", networkPaht, user, pwd);
				int code = WNetAddConnection2(ref netResource, pwd, user, 0);
				if (code != 0)
				{
					logger.Warn("ネットワーク接続 エラーコード[{0}]", code);
				}
				return true;
			}
			catch (Exception ex)
			{
				logger.Warn("ネットワーク接続でエラーが発生\n" + ex);
				return false;
			}
		}
		#endregion
	}
}
