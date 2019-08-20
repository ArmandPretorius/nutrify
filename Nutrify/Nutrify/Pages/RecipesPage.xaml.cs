using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        public RecipesPage()
        {
            InitializeComponent();

            recipeList.ItemsSource = new List<Name>()
           {new Name(){ name="This is Ist Message" },
            new Name(){ name="This is 2nd Message"} };
        }


    }
}

class Name
{
    public string name { get; set; }
}