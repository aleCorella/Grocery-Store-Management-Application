using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PryDesarrolloAppsDueño.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropetyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
