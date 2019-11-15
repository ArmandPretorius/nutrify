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
            }
        }
    }
}