using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NutrientsResultPage : ContentPage
    {
        HttpClient client;
        private string foodAppId = "4b8595d9";
        private string foodAppKey = "d6e12ea7b4748aa39affc712f654bf7a";
        private string result;

        public NutrientsResultPage(string search)
        {
            result = search;
            GetNutrients(result);
            InitializeComponent();
        }

            private async void GetNutrients(string food)
        {

            client = new HttpClient();

            try
            {
                Console.WriteLine("-------------------------------SEARCHING");

                var response = await client.GetStringAsync("https://api.edamam.com/api/food-database/parser?ingr=" + food + "&app_id=" + foodAppId + "&app_key=" + foodAppKey);

                Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(response);

                var nutrients = JsonConvert.DeserializeObject(response);
                //Console.WriteLine(nutrients);

                foodName.Text = (string)jObject["parsed"][0]["food"]["label"];
                foodEnergy.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["ENERC_KCAL"];
                foodProtein.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["PROCNT"];
                foodFat.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["FAT"];
                foodCals.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["CHOCDF"];
                foodFibre.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["FIBTG"];

                Console.WriteLine("-------------------------------GOT IT");
            }
            catch
            {
                await Navigation.PushAsync(new NotFoundPage("We couldn't Nutrify the food you were looking for. Please go back and try again.", "backGreen"));
            }
           
        }

        private void Recipe_Search_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new RecipesPage(result));
        }

        private void Back_Search_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}