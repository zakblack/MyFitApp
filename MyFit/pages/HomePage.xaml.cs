using MyFit.models;
using MyFit.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFit.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            
          
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
           var mydetails = e.Item as Course;
           await Navigation.PushAsync(new CoursePageDetail(mydetails.courseStart, mydetails.calories.ToString(), mydetails.steps.ToString(), mydetails.maptrack));

        }

        private async void NewCourse_Clicked(object sender, EventArgs e)
        {
            await  App.Current.MainPage.Navigation.PushModalAsync(new NewCoursePage());

        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {

            Settings.UserToken = "";
            Settings.UserId = "";
            Settings.UserFullName = "";
            Settings.UserHeight = "";
            Settings.UserWeight = "";
            Settings.UserCoursesList = "";

            await App.Current.MainPage.Navigation.PopModalAsync();

        }
    }
}