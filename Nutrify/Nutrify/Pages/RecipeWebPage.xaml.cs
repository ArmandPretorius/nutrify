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
    public partial class RecipeWebPage : ContentPage
    {
        public RecipeWebPage(string url, string label)
        {
            InitializeComponent();
            webview.Source = url;
            Title = label;


        }
    }
}