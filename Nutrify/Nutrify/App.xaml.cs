using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrify
{
    public partial class App : Application
    {

        public static string FilePath;

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

        public App(string filePath)
        {
            InitializeComponent();

            // MainPage = new Pages.RecipesPage("Banana");
            MainPage = new NavigationPage(new Pages.SearchPage())
            {
                BarBackgroundColor = Color.FromHex("#F8AA08"),
                BarTextColor = Color.White
            };

            FilePath = filePath;

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
