using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrify.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeBookPage : ContentPage
    {


        public RecipeBookPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                var recipeBook = conn.Table<RecipeBook>().ToList();

                if (recipeBook.Count == 0)
                {
                    errorImage.IsVisible = true;
                    errorMessage.IsVisible = true;
                    recipeBookList.IsVisible = false;
                }

                recipeBookList.ItemsSource = recipeBook; //set listview equal to list with data.
            }
        }

        private void RecipeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var viewCell = (ViewCell)sender;
            //if (viewCell.View != null)
            //{
            //    viewCell.View.BackgroundColor = Color.Transparent;
            //}

            if (recipeBookList.SelectedItem != null)
            {
                //Set selected conversation information
                var selectedRecipe = (RecipeBook)recipeBookList.SelectedItem;
                //Console.WriteLine("_______________________________________________________________________________________________________________________________________" + selectedRecipe.Id);
                Recipe readRecipe = new Recipe()
                {
                    label = selectedRecipe.Label,
                    image = selectedRecipe.Image,
                    calories = selectedRecipe.Calories,
                    totalTime = selectedRecipe.TotalTime,
                    url = selectedRecipe.Url
                };

                Navigation.PushAsync(new RecipeWebPage(readRecipe));
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var recipeId = button.CommandParameter;
            Console.WriteLine("_____________________________________________________________________________TAPPEDREMOVE  " + recipeId);
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                conn.Delete<RecipeBook>(recipeId);
            }
            OnAppearing();
        }
    }
}