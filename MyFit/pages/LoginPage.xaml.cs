﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFit.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}