using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MyFit.helpers;
using Newtonsoft.Json.Linq;

namespace MyFit.models
{
    class CoursesViewModel
    {
        public ObservableCollection<Course> Courses { get; set; }

        public CoursesViewModel()
        {

            
            
            Courses = new ObservableCollection<Course>();
            //JObject o = JObject.Parse(Settings.UserCoursesList);
            JArray a = JArray.Parse(Settings.UserCoursesList);
            Courses = a.ToObject<ObservableCollection<Course>>();

            //Alert(Settings.UserFullName);

        }

        public async void Alert(string Message)
        {
            await App.Current.MainPage.DisplayAlert("Bienvenue", Message, "Ok");
        }
    }
}
