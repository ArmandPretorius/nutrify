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

           //MainPage = new Pages.NotFoundPage("We Couldn't Nutrify that type of food. Please try again", "greenCharacter", "backGreen");
          //  MainPage = new Pages.RecipesPage("Apple");
            MainPage = new NavigationPage(new Pages.SearchPage());
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
