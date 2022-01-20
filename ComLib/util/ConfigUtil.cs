using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Configuration;
using System.Drawing;
using System.Reflection;

namespace ComLib
{
	/// <summary>
	/// app.Config�A�N�Z�X ���[�e�B���e�B
	/// </summary>
	public static class ConfigUtil
	{
		#region [public]���\�b�h
		/// <summary>
		/// app.config�t�@�C���̃p�X
		/// </summary>
		public static string AppConfigPath
		{
			get
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				string configPath = Path.Combine(Path.GetDirectoryName(asm.Location), Process.GetCurrentProcess().ProcessName);
				configPath += ".exe.config";
				return configPath;
			}
		}

		/// <summary>
		/// �ݒ�l�擾(����)
		/// </summary>
		/// <param name="settingName">�G���g���[��</param>
		/// <param name="defVal">�f�t�H���g�l</param>
		/// <returns>�ݒ�l</returns>
		public static string StrVal(string settingName, string defVal)
		{
			if (Array.IndexOf(ConfigurationManager.AppSettings.AllKeys, settingName) >= 0)
			{
				return ConfigurationManager.AppSettings[settingName];
			}
			else
			{
				return defVal;
			}
		}
		/// <summary>
		/// �ݒ�l�擾(���l)
		/// </summary>
		/// <param name="vIsetting">�ݒ薼��</param>
		/// <param name="vIdef">�f�t�H���g�l</param>
		/// <returns>���l</returns>
		public static int IntVal(string settingName, int vIdef)
		{
			string val = StrVal(settingName, "");
			int result = 0;
			if (int.TryParse(val, out result) == false)
			{
				result = vIdef;
			}
			return result;
		}
		/// <summary>
		/// �ݒ�l�擾(����List)
		/// </summary>
		/// <param name="settingName">�G���g���[��</param>
		/// <param name="defVal">�f�t�H���g�l</param>
		/// <returns>�ݒ�l</returns>
		public static List<string> ListVal(string settingName, string defVal)
		{
			string val = StrVal(settingName, defVal);
			return StrUtil.Split(val, ",");
		}
		#endregion
	}
}