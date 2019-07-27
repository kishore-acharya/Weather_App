using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Weather_App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public object Param { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}