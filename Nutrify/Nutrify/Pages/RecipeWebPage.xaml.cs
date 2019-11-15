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

            //var button = sender as ImageButton;
            //var recipeId = button.CommandParameter;
            //var saved = button.Source.ToString();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                var recipeBookList = conn.Table<RecipeBook>().ToList();

                foreach(var rec in recipeBookList)
                {
                    if (rec.Label != recipeSaver.label)
                    {
                        int rowsAdded = conn.Insert(recipe);
                        SaveToDatabaseButton.Source = "heartFilled";
                        //SaveToDatabaseButton.CommandParameter = rowsAdded;
                        Console.WriteLine("_________________________________________________________Saved" + rowsAdded);
                    }
                }
            } 
            //else
            //{
            //    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            //    {
            //        conn.CreateTable<RecipeBook>();
            //        conn.Delete<RecipeBook>(recipeId);
            //        Console.WriteLine("_________________________________________________________Removed");
            //    }
            //    SaveToDatabaseButton.Source = "heart";
            //}

           

        }
    }
}