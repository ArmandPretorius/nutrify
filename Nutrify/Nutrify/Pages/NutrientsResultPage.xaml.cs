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

        public NutrientsResultPage(string search)
        {
            var result = search;
            InitializeComponent();
            GetNutrients(result);
        }

            private async void GetNutrients(string food)
        {
            client = new HttpClient();

            var response = await client.GetStringAsync("https://api.edamam.com/api/food-database/parser?ingr="+ food + "&app_id=4b8595d9&app_key=d6e12ea7b4748aa39affc712f654bf7a");

            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(response);

            var nutrients = JsonConvert.DeserializeObject(response);
            //Console.WriteLine(nutrients);

            foodName.Text = (string)jObject["parsed"][0]["food"]["label"];
            foodEnergy.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["ENERC_KCAL"];
            foodProtein.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["PROCNT"];
            foodFat.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["FAT"];
            foodCals.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["CHOCDF"];
            foodFibre.Text = (string)jObject["parsed"][0]["food"]["nutrients"]["FIBTG"];
       

        }
    }
}