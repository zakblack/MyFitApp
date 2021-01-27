
using MyFit.models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFit.helpers;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MyFit.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCoursePage : ContentPage
    {
        JArray CoursesLocations;
        RestService _restService = new RestService();
        System.Timers.Timer aTimer = new System.Timers.Timer(1000);

        public NewCoursePage()
        {
            InitializeComponent();

            CoursesLocations = new JArray();
            
            

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Interval = 5000; //millisecondes
            aTimer.Enabled = true;

            //if your code is not registers timer globally then uncomment following code

            //GC.KeepAlive(aTimer);



           
        }

        JObject temp;
        public async Task GetCurrentLocation()
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            JObject loc = new JObject();

            loc["Latitude"] = location.Latitude;
            loc["Longitude"] = location.Longitude;

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    loc["Latitude"] = location.Latitude;
                    loc["Longitude"] = location.Longitude;
                   Console.WriteLine($"hada ana Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    temp = loc;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            temp = loc;
        }


        public async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            await GetCurrentLocation();
            
            CoursesLocations.Add(temp);
        }

        CancellationTokenSource cts;
   

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }
       
        private async void Finish_Clicked(object sender, EventArgs e)
        {
           aTimer.Enabled = false;
           var tour = new Course
            {
                courseStart = DateTime.Now.ToString("yyyy-MM-dd"),
                calories = 555,
                steps = 4578,
                maptrack = JsonConvert.SerializeObject(CoursesLocations),
                user = Settings.UserId
            };

            
            var issucced = await _restService.CourseAddAsync(tour.calories, tour.steps, tour.maptrack);
            if(issucced)
             {
                //Debug.WriteLine(tour.mapTrack);
                JArray a = JArray.Parse(Settings.UserCoursesList);
                a.Add(JToken.FromObject(tour));
                Settings.UserCoursesList = a.ToString();

                //Debug.WriteLine(Settings.UserCoursesList);

                await App.Current.MainPage.Navigation.PopModalAsync();
            }

            
        }
    }
}