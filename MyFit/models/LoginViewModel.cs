using MyFit.helpers;
using MyFit.pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFit.models
{
    
    class LoginViewModel
    {
        public string password { get; set; }
        public string identifier { get; set; }

        RestService _restService = new RestService();

        public ICommand LoginCommand
        {
            get
            {
                return new Command(
                    async () =>
                    {

                        var issucced = await _restService.LoginAsync(identifier, password);

                        if (issucced)

                        {
                           await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Erreur", "Essayer plus tard", "Ok");
                        }
                    });
            }
        }

       
    }
}
