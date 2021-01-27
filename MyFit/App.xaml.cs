using MyFit.pages;
using Xamarin.Forms;

namespace MyFit
{

    public partial class App : Application
    {
       
        public App()
        {
 
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
