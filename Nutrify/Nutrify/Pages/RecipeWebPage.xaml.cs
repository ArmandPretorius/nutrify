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

            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                var recipeBookList = conn.Table<RecipeBook>().ToList();

                foreach (var rec in recipeBookList)
                {
                    if (rec.Label == recipe.label)
                    {
                        saveButton.IsVisible = false;
                        deleteButton.IsVisible = true;
                    }
                }
            }

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SaveToDatabaseButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            RecipeBook recipe = new RecipeBook()
            {
                Label = recipeSaver.label,
                Image = recipeSaver.image,
                Calories = recipeSaver.calories,
                TotalTime = recipeSaver.totalTime,
                Url = recipeSaver.url
            };

            
            //var recipeId = button.CommandParameter;
            //var saved = button.Source.ToString();
            using (
                SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                var recipeBookList = conn.Table<RecipeBook>().ToList();

                int rowsAdded = conn.Insert(recipe);
                saveButton.IsVisible = false;
                deleteButton.IsVisible = true;
            } 

        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            RecipeBook recipe = new RecipeBook()
            {
                Label = recipeSaver.label,
                Image = recipeSaver.image,
                Calories = recipeSaver.calories,
                TotalTime = recipeSaver.totalTime,
                Url = recipeSaver.url
            };


            //var recipeId = button.CommandParameter;
            //var saved = button.Source.ToString();
            using (
                SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<RecipeBook>();
                var recipeBookList = conn.Table<RecipeBook>().ToList();

                foreach (var rec in recipeBookList)
                { 
                    if (rec.Label == recipeSaver.label)
                    {
                        int rowsDeleted = conn.Delete<RecipeBook>(rec.Id);
                        saveButton.IsVisible = true;
                        deleteButton.IsVisible = false;
                    }
                }
            }
        }
    }
}