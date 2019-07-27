using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather_App.ViewModels;
using Xamarin.Forms;

namespace Weather_App.Helpers
{
    public static class NavigationService
    {
        public static async Task<bool> Navigate(Page page, BaseViewModel viewmodel, bool hasParam = false, object param = null)
        {
            if (hasParam)
            {
                page.BindingContext = viewmodel;
                viewmodel.Param = param;
                viewmodel.Initialize();
                await Application.Current.MainPage.Navigation.PushAsync(page);

            }
            else
            {   
                page.BindingContext = viewmodel;
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }

            return true;
        }
    }
}
