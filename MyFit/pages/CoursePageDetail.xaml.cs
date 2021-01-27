using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace MyFit.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePageDetail : ContentPage
    {
        public class CourseLocation
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        
        void TrackPath_Clicked(string trackPathFile)
        {
            //var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            var myJson = JsonConvert.DeserializeObject<List<Xamarin.Forms.GoogleMaps.Position>>(trackPathFile);

            map.Polylines.Clear();

            var polyline = new Xamarin.Forms.GoogleMaps.Polyline();
            polyline.StrokeColor = Color.Black;
            polyline.StrokeWidth = 3;

            foreach (var p in myJson)
            {
                polyline.Positions.Add(p);

            }
            map.Polylines.Add(polyline);

        

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(polyline.Positions[0].Latitude, polyline.Positions[0].Longitude), Xamarin.Forms.GoogleMaps.Distance.FromMiles(0.50f)));
        }
        public CoursePageDetail(string coursestart, string Calories, string Steps, string mapTrack)
        {
            InitializeComponent();

            //maptrack.Text = mapTrack;
            //steps.Text = Steps;
            //calories.Text = Calories;
            //string test = "[{\"Latitude\":28.12267,\"Longitude\":82.29483},{\"Latitude\":28.12306,\"Longitude\":82.29433},{\"Latitude\":28.12357,\"Longitude\":82.29379},{\"Latitude\":28.12369,\"Longitude\":82.29367},{\"Latitude\":28.12375,\"Longitude\":82.29365},{\"Latitude\":28.12386,\"Longitude\":82.29361},{\"Latitude\":28.12398,\"Longitude\":82.29367},{\"Latitude\":28.12442,\"Longitude\":82.29388},{\"Latitude\":28.12503,\"Longitude\":82.29415},{\"Latitude\":28.12562,\"Longitude\":82.29443},{\"Latitude\":28.12616,\"Longitude\":82.29467},{\"Latitude\":28.12902,\"Longitude\":82.29607},{\"Latitude\":28.13186,\"Longitude\":82.29739},{\"Latitude\":28.13326,\"Longitude\":82.29809},{\"Latitude\":28.13316,\"Longitude\":82.29852},{\"Latitude\":28.13303,\"Longitude\":82.2988},{\"Latitude\":28.13298,\"Longitude\":82.299},{\"Latitude\":28.13258,\"Longitude\":82.29989},{\"Latitude\":28.13258,\"Longitude\":82.2999}]";

            TrackPath_Clicked(mapTrack);


        }
    }
}