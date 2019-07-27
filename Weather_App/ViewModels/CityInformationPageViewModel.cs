using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Weather_App.ViewModels
{
   public class CityInformationPageViewModel:BaseViewModel

    {
        public string CityName { get; set; }
        public string URI { get; set; }
        public bool isLoading { get; set; }

        public string ErrorText { get; set; }
        public bool WebViewVisible { get; set; } = false;
        public bool ErrorVisible { get; set; } = false;
        public CityInformationPageViewModel()
        {
            
        }
        public override void Initialize()
        {
            if (Param == null || (String)Param==" " || (String)Param=="")
            {
                ErrorText = "You have entered wrong value in City";
                ErrorVisible = true;
                OnPropertyChanged("ErrorText");
                OnPropertyChanged("ErrorVisible");
            }
            else
            {
                WebViewVisible = true;
                CityName = (String)Param;
                OnPropertyChanged(CityName);
                URI = "https://en.wikipedia.org/wiki/" + CityName;
                OnPropertyChanged("URI");
                OnPropertyChanged("WebViewVisible");
            }
           
           

        }


        public void SetIsLoadingTrue()
        {
            isLoading=true;
            OnPropertyChanged("isLoading");
        }

        public void SetIsLoadingFalse()
        {
            isLoading = false;
            OnPropertyChanged("isLoading");
        }
    }
}
