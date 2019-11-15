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

                recipeBookList.ItemsSource = recipeBook; //set listview equal to list with data.
            }
        }

        private void RecipeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (recipeBookList.SelectedItem != null)
            {
                //Set selected conversation information
                var selectedRecipe = (RecipeBook)recipeBookList.SelectedItem;
                Console.WriteLine("_______________________________________________________________________________________________________________________________________" + selectedRecipe.Url);

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
    }
}