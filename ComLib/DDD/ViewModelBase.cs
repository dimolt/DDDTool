using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComLib.DDD.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field
            , T value
            , [CallerMemberName] string propertyName = null)
        {
            //値変更なし　→　何もしない
            if (Equals(field, value))
            {
                return false;
            }

            //値変更あり → 通知
            field = value;
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }

            return true;
        }

        public void OnpropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this
                , new PropertyChangedEventArgs(propertyName));
        }
    }
}
