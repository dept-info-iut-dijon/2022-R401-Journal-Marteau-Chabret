using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    /// <summary>
    /// Base
    /// </summary>
    internal class BaseVM : INotifyPropertyChanged
    {
        #region INOTIFY
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}
