using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        HttpClient client;
        private string foodAppId = "00814198";
        private string foodAppKey = "733f3bd5ce4816806fda09c020a90128";
        public RecipesPage(string search)
        {
            InitializeComponent();

         //   GetRecipes(search);

            recipeList.ItemsSource = new List<Name>()
           {new Name(){ name="This is Ist Message" },
           new Name(){ name="This is Ist Message" },
           new Name(){ name="This is Ist Message" },
           new Name(){ name="This is Ist Message" },
           new Name(){ name="This is Ist Message" },
           new Name(){ name="This is Ist Message" },
           new Name(){ name="This is Ist Message" },
            new Name(){ name="This is 2nd Message"} };
        }

        private async void GetRecipes(string food)
        {
            client = new HttpClient();

            var response = await client.GetStringAsync(" https://api.edamam.com/search?q=" + food + "&app_id=" + foodAppId + "&app_key=" + foodAppKey);

            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(response);

            var recipes = JsonConvert.DeserializeObject(response);
        }
    }
}

class Name
{
    public string name { get; set; }
}