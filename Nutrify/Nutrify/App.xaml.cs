using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // MainPage = new Pages.RecipesPage("Banana");
            MainPage = new NavigationPage(new Pages.SearchPage())
            {
                BarBackgroundColor = Color.FromHex("#F8AA08"),
                BarTextColor = Color.White
            };
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
