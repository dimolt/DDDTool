using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComLib.DDD.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var vo = obj as T;
            if (vo == null)
            {
                return false;
            }

            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> vol1
            , ValueObject<T> vol2)
        {
            return Equals(vol1, vol2);
        }
        public static bool operator !=(ValueObject<T> vol1
            , ValueObject<T> vol2)
        {
            return !Equals(vol1, vol2);
        }

        //各クラスで実装
        protected abstract bool EqualsCore(T other);

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
