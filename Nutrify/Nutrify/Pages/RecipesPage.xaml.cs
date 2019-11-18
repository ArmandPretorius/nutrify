using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using Nutrify.Classes;

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        HttpClient client;
        private string foodAppId = "00814198";
        private string foodAppKey = "733f3bd5ce4816806fda09c020a90128";

        public string foodSearch;

        public RecipesPage(string search)
        {
            InitializeComponent();

            foodName.Text = search;
            foodSearch = search;
           

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetRecipes(foodSearch);
        }

        private void Back_Nutrients_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }

        private async void GetRecipes(string food)
        {
            client = new HttpClient();

            try
            {
                var response = await client.GetStringAsync("https://api.edamam.com/search?q=" + food + "&app_id=" + foodAppId + "&app_key=" + foodAppKey);

                Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(response);

                //RESPONSE OBJECT ARRAY OF HITS
                Object hits = jObject["hits"];

                //STACK OVERFLOW EXAMPLE
                var root = JsonConvert.DeserializeObject<List<Hit>>(hits.ToString());

                RootObject getRequest = new RootObject() { hits = root };

                var recipeListing = new List<Recipe>(); //var to add recipes to in loop
                var recipeBookListing = new List<Recipe>();

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<RecipeBook>();
                    var recipeBookList = conn.Table<RecipeBook>().ToList();

                    //loops through the jObjects array and adds the data to recipeListing for listview
                    for (int ndx = 0; ndx < jObject["hits"].Count(); ndx++)
                    {
                        recipeListing.Add(new Recipe
                        {
                            label = getRequest.hits[ndx].recipe.label,
                            image = getRequest.hits[ndx].recipe.image,
                            url = getRequest.hits[ndx].recipe.url,
                            calories = Math.Truncate(getRequest.hits[ndx].recipe.calories * 100) / 100,
                            totalTime = getRequest.hits[ndx].recipe.totalTime,
                            saveicon = "heart",
                        });


                        foreach (var rec in recipeBookList)
                        {
                            //Check if is in recipebook
                            if (rec.Label == getRequest.hits[ndx].recipe.label)
                            {
                                recipeListing.Add(new Recipe
                                {
                                    label = rec.Label,
                                    image = rec.Image,
                                    url = rec.Url,
                                    calories = rec.Calories,
                                    totalTime = rec.TotalTime,
                                    recipeBookId = rec.Id,
                                    saveicon = "heartFilled"
                                });
                            }
                        }  

                    }

                    //foreach (var rec in recipeListing)
                    //{
                        
                    //}

                }
            
                loadingRecipeIndicator.IsVisible = false;
                loadingRecipeIndicator.IsRunning = false;
               
                recipeList.ItemsSource = recipeListing; //set listview equal to list with data.
            
            }
            catch
            {
                //navigate to error page
                await Navigation.PushAsync(new NotFoundPage("We couldn't find recipes matching that food.", "backYellow"));
            }

    }
    

        private void RecipeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (recipeList.SelectedItem != null)
            {
                //Set selected conversation information
                var selectedRecipe = (Recipe)recipeList.SelectedItem;
                Console.WriteLine("_______________________________________________________________________________________________________________________________________" + selectedRecipe.url);

                Navigation.PushAsync(new RecipeWebPage(selectedRecipe));

               

            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var recipeSaver = button.CommandParameter as Recipe;

            // Console.WriteLine(recipeSaver.label);

            RecipeBook recipe = new RecipeBook()
            {
                Label = recipeSaver.label,
                Image = recipeSaver.image,
                Calories = recipeSaver.calories,
                TotalTime = recipeSaver.totalTime,
                Url = recipeSaver.url
            };

            if(recipeSaver.saveicon == "heart")
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<RecipeBook>();
                    var recipeBookList = conn.Table<RecipeBook>().ToList();
                    int rowsAdded = conn.Insert(recipe);

                    button.Source = "heartFilled";

                }
            }

            if(recipeSaver.saveicon == "heartFilled")
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<RecipeBook>();
                    conn.Delete<RecipeBook>(recipeSaver.recipeBookId);
                }
            }

        }


    }
}
