using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    /// <summary>
    /// Base
    /// </summary>
    public class BaseVM : INotifyPropertyChanged
    {
        #region INOTIFY
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName= "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
