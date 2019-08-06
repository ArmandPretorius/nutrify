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
        public NutrientsResultPage()
        {
            InitializeComponent();

            GetNutrients();
        }

        private async void GetNutrients()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("https://api.edamam.com/api/food-database/parser?ingr=apple&app_id=4b8595d9&app_key=d6e12ea7b4748aa39affc712f654bf7a");

            var nutrients = JsonConvert.DeserializeObject<List<Classes.Food>>(response);

            NutrientsListView.ItemsSource = nutrients;

        }
    }
}