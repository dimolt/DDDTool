using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ComLib
{
	/// <summary>
	/// XML操作
	/// </summary>
	public static class XmlUtil
	{
		#region プロパティ
		/// <summary>
		/// 操作対象 XMLドキュメント
		/// </summary>
		public static XmlDocument Doc
		{
			get;
			private set;
		}
		/// <summary>
		/// 操作対象 XML ネームスペース
		/// </summary>
		public static XmlNamespaceManager nsMng
		{
			get;
			private set;
		}
		#endregion

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="mng"></param>
		public static void Initialize(XmlDocument doc)
		{
			Doc = doc;
			nsMng = new XmlNamespaceManager(doc.NameTable);
		}

		/// <summary>
		/// ノード文字列取得
		/// </summary>
		/// <param name="vIparent">親ノード</param>
		/// <param name="vInodeName">ノード名</param>
		/// <returns>文字列</returns>
		public static string NodeStr(XmlNode vInode, string vInodeName)
		{
			if (vInode == null)
			{
				return "";
			}

			var node = vInode.SelectSingleNode(vInodeName);
			return (node == null ? "" : node.Value);
		}
		/// <summary>
		/// 属性の値取得
		/// </summary>
		/// <param name="vIparent">ノード</param>
		/// <param name="vIattribute">属性名</param>
		/// <returns>文字列</returns>
		public static string Attribute(XmlNode vInode, string vIattribute)
		{
			if (vInode == null)
			{
				return "";
			}

			var attribute = vInode.Attributes[vIattribute];
			return (attribute == null ? "" : attribute.Value);
		}

		/// <summary>
		/// ノード取得
		/// </summary>
		/// <param name="root">親ノード</param>
		/// <param name="xPath">パス</param>
		/// <returns>ノード</returns>
		public static XmlNode GetNode(XmlNode root, string xPath)
		{
			return root.SelectSingleNode(xPath, nsMng);
		}
		/// <summary>
		/// ノード 値取得
		/// </summary>
		/// <param name="root">親ノード</param>
		/// <param name="xPath">パス</param>
		/// <returns>値</returns>
		public static string NodeValue(XmlNode root, string xPath)
		{
			XmlNode node = GetNode(root, xPath);
			return (node == null) ? "" : node.Value;
		}
		/// <summary>
		/// ノード 値設定
		/// </summary>
		/// <param name="root">親ノード</param>
		/// <param name="xPath">パス</param>
		/// <param name="value">値</param>
		public static void SetNodeValue(XmlNode root, string xPath, string value)
		{
			XmlNode node = GetNode(root, xPath);
			if (node != null)
			{
				node.InnerText = value;
			}
		}
		/// <summary>
		/// 子ノード追加
		/// </summary>
		/// <param name="node">親ノード</param>
		/// <param name="prefix">prefix</param>
		/// <param name="localName">名称</param>
		/// <param name="ns">ネームスペース</param>
		/// <param name="value">値</param>
		/// <returns>子ノード</returns>
		public static XmlNode AddChild(XmlNode node, string prefix, string localName, XNamespace ns, string value)
		{
			XmlNode child = Doc.CreateElement(prefix, localName, ns.NamespaceName);
			child.InnerText = value;
			node.AppendChild(child);

			return child;
		}
		/// <summary>
		/// 属性 追加
		/// </summary>
		/// <param name="node">親ノード</param>
		/// <param name="prefix">prefix</param>
		/// <param name="localName">名称</param>
		/// <param name="ns">ネームスペース</param>
		/// <param name="value">値</param>
		public static void AddAttribute(XmlNode node, string prefix, string localName, XNamespace ns, string value)
		{
			if (node == null)
			{
				return;
			}
			XmlAttribute attr = Doc.CreateAttribute(prefix, localName, ns.NamespaceName);
			attr.Value = value;
			node.Attributes.Append(attr);
		}
		/// <summary>
		/// 属性 追加
		/// </summary>
		/// <param name="node">親ノード</param>
		/// <param name="name">名称</param>
		/// <param name="value">値</param>
		public static void AddAttribute(XmlNode node, string name, string value)
		{
			if (node == null)
			{
				return;
			}
			XmlAttribute attr = Doc.CreateAttribute(name);
			attr.Value = value;
			node.Attributes.Append(attr);
		}

		/// <summary>
		/// 属性 値設定
		/// </summary>
		/// <param name="node">親ノード</param>
		/// <param name="name">属性名</param>
		/// <param name="value">値</param>
		public static void SetAttrVal(XmlNode node, string name, string value)
		{
			if (node == null)
			{
				return;
			}

			var attribute = node.Attributes[name];
			if (attribute != null)
			{
				attribute.Value = value;
			}
		}
	}
}
