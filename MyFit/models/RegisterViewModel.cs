
using MyFit.helpers;
using MyFit.pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace MyFit.models
{
    class RegisterViewModel
    {
        
        RestService _restService = new RestService();

       

        public string password { get; set; }
        public string username { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public int poids { get; set; }
        public int height { get; set; }
        public int age { get; set; }
  

       public ICommand RegisterCommand
        {
                get
            {
                return new Command(
                    async () =>
                    {
                       var issucced =  await _restService.RegisterAsync(email, password, username, poids, height, age, fullname);

                        if (issucced)

                        {
                            App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Erreur", "Essayer plus tard", "Ok");
                        }
                    });
            }
        }

    }
}
