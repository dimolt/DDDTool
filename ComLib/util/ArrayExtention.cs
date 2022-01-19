using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComLib.util
{
    public static class ArrayExtention
    {
        /// <summary>
        /// 配列要素
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="self">配列</param>
        /// <param name="idx">インデックス</param>
        /// <returns>要素</returns>
        /// <remarks>1次元配列専用</remarks>
        public static T At<T>(this Array self, int idx)
        {
            if ((idx < 0) || idx >= (self.Length)) return default(T);

            return (T)self.GetValue(idx);
        }
    }
}
