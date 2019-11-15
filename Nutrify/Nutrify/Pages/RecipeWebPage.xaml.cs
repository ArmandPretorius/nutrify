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
    public partial class RecipeWebPage : ContentPage
    {
        private static Recipe recipeSaver;

        public RecipeWebPage(Recipe recipe)
        {
            InitializeComponent();
            webview.Source = recipe.url;
            Title.Text = recipe.label;

            recipeSaver = recipe;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveToDatabaseButton_Clicked(object sender, EventArgs e)
        {
            RecipeBook recipe = new RecipeBook()
            {
                Label = recipeSaver.label,
                Image = recipeSaver.image,
                Calories = recipeSaver.calories,
                TotalTime = recipeSaver.totalTime,
                Url = recipeSaver.url
            };

            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                int rowsAdded = conn.Insert(recipe);
            }

        }
    }
}