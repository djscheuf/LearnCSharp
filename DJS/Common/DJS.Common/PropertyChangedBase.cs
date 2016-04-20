using System;
using System.ComponentModel;
using System.Windows;

namespace DJS.Common
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            try
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    var handler = PropertyChanged;
                    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                }));
            }
            catch (Exception)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
