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

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        HttpClient client;
        private string foodAppId = "00814198";
        private string foodAppKey = "733f3bd5ce4816806fda09c020a90128";

        public List<Ingredient> ingredients;

        public RecipesPage(string search)
        {
            InitializeComponent();

            foodName.Text = search;
            GetRecipes(search);

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

                //loops through the jObjects array and adds the data to recipeListing for listview
                for (int ndx = 0; ndx < jObject["hits"].Count(); ndx++)
                {
                    recipeListing.Add(new Recipe {
                        label = getRequest.hits[ndx].recipe.label,
                        image = getRequest.hits[ndx].recipe.image,
                        calories = Math.Truncate(getRequest.hits[ndx].recipe.calories * 100) / 100,
                        totalTime = getRequest.hits[ndx].recipe.totalTime });

                  //  ingredients = getRequest.hits[ndx].recipe.ingredients;
                }

                recipeList.ItemsSource = recipeListing; //set listview equal to list with data.
               
            }
            catch
            {
                //navigate to error page
                await Navigation.PushAsync(new NotFoundPage("We couldn't find recipes matching that food.", "greenCharacter", "backYellow"));
            }

        }

        private void RecipeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine("Tapped!");
            if (recipeList.SelectedItem != null)
            {
                //Set selected conversation information
                var selectedRecipe = (Recipe)recipeList.SelectedItem;
                Console.WriteLine(selectedRecipe);
                //Navigate to recipeinfo page
             //   Navigation.PushAsync(new NotFoundPage(selectedRecipe, ingredients)); ;

                //Send Information
             //   MessagingCenter.Send<Page, Class>(this, "ConvoProp", selectConvo);

            }
            //Navigation.PushAsync(new NotFoundPage("We couldn't find recipes matching that food.", "greenCharacter", "backYellow"));
        }
    }
}


    //CLASSES OF API
public class Params
{
    public List<object> sane { get; set; }
    public List<string> q { get; set; }
    public List<string> app_key { get; set; }
    public List<string> app_id { get; set; }
}

public class Ingredient
{
    public string text { get; set; }
    public double weight { get; set; }
}

public class ENERCKCAL
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FAT
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FASAT
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FATRN
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FAMS
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FAPU
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class CHOCDF
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FIBTG
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class SUGAR
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class PROCNT
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class CHOLE
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class NA
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class CA
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class MG
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class K
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FE
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class ZN
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class P
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITARAE
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITC
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class THIA
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class RIBF
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class NIA
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITB6A
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FOLDFE
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FOLFD
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITB12
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITD
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class TOCPHA
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITK1
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FOLAC
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class TotalNutrients
{
    public ENERCKCAL ENERC_KCAL { get; set; }
    public FAT FAT { get; set; }
    public FASAT FASAT { get; set; }
    public FATRN FATRN { get; set; }
    public FAMS FAMS { get; set; }
    public FAPU FAPU { get; set; }
    public CHOCDF CHOCDF { get; set; }
    public FIBTG FIBTG { get; set; }
    public SUGAR SUGAR { get; set; }
    public PROCNT PROCNT { get; set; }
    public CHOLE CHOLE { get; set; }
    public NA NA { get; set; }
    public CA CA { get; set; }
    public MG MG { get; set; }
    public K K { get; set; }
    public FE FE { get; set; }
    public ZN ZN { get; set; }
    public P P { get; set; }
    public VITARAE VITA_RAE { get; set; }
    public VITC VITC { get; set; }
    public THIA THIA { get; set; }
    public RIBF RIBF { get; set; }
    public NIA NIA { get; set; }
    public VITB6A VITB6A { get; set; }
    public FOLDFE FOLDFE { get; set; }
    public FOLFD FOLFD { get; set; }
    public VITB12 VITB12 { get; set; }
    public VITD VITD { get; set; }
    public TOCPHA TOCPHA { get; set; }
    public VITK1 VITK1 { get; set; }
    public FOLAC FOLAC { get; set; }
}

public class ENERCKCAL2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FAT2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FASAT2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class CHOCDF2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FIBTG2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class PROCNT2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class CHOLE2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class NA2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class CA2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class MG2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class K2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FE2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class ZN2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class P2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITARAE2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITC2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class THIA2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class RIBF2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class NIA2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITB6A2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class FOLDFE2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITB122
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITD2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class TOCPHA2
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class VITK12
{
    public string label { get; set; }
    public double quantity { get; set; }
    public string unit { get; set; }
}

public class TotalDaily
{
    public ENERCKCAL2 ENERC_KCAL { get; set; }
    public FAT2 FAT { get; set; }
    public FASAT2 FASAT { get; set; }
    public CHOCDF2 CHOCDF { get; set; }
    public FIBTG2 FIBTG { get; set; }
    public PROCNT2 PROCNT { get; set; }
    public CHOLE2 CHOLE { get; set; }
    public NA2 NA { get; set; }
    public CA2 CA { get; set; }
    public MG2 MG { get; set; }
    public K2 K { get; set; }
    public FE2 FE { get; set; }
    public ZN2 ZN { get; set; }
    public P2 P { get; set; }
    public VITARAE2 VITA_RAE { get; set; }
    public VITC2 VITC { get; set; }
    public THIA2 THIA { get; set; }
    public RIBF2 RIBF { get; set; }
    public NIA2 NIA { get; set; }
    public VITB6A2 VITB6A { get; set; }
    public FOLDFE2 FOLDFE { get; set; }
    public VITB122 VITB12 { get; set; }
    public VITD2 VITD { get; set; }
    public TOCPHA2 TOCPHA { get; set; }
    public VITK12 VITK1 { get; set; }
}

public class Sub
{
    public string label { get; set; }
    public string tag { get; set; }
    public string schemaOrgTag { get; set; }
    public double total { get; set; }
    public bool hasRDI { get; set; }
    public double daily { get; set; }
    public string unit { get; set; }
}

public class Digest
{
    public string label { get; set; }
    public string tag { get; set; }
    public string schemaOrgTag { get; set; }
    public double total { get; set; }
    public bool hasRDI { get; set; }
    public double daily { get; set; }
    public string unit { get; set; }
    public List<Sub> sub { get; set; }
}

public class Recipe
{
    public string uri { get; set; }
    public string label { get; set; }
    public string image { get; set; }
    public string source { get; set; }
    public string url { get; set; }
    public string shareAs { get; set; }
    public double yield { get; set; }
    public List<object> dietLabels { get; set; }
    public List<string> healthLabels { get; set; }
    public List<object> cautions { get; set; }
    public List<string> ingredientLines { get; set; }
    public List<Ingredient> ingredients { get; set; }
    public double calories { get; set; }
    public double totalWeight { get; set; }
    public double totalTime { get; set; }
    public TotalNutrients totalNutrients { get; set; }
    public TotalDaily totalDaily { get; set; }
    public List<Digest> digest { get; set; }
}

public class Hit
{
    public Recipe recipe { get; set; }
    public bool bookmarked { get; set; }
    public bool bought { get; set; }
}

public class RootObject
{
    public string q { get; set; }
    public int from { get; set; }
    public int to { get; set; }
    public Params @params { get; set; }
    public bool more { get; set; }
    public int count { get; set; }
    public List<Hit> hits { get; set; }
}