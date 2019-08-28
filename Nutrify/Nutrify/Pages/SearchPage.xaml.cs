using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Nutrify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {

        public SearchPage()
        {
            InitializeComponent();

            searchInput.Completed += (sender, e) => {
                var result = searchInput.Text;
                Navigation.PushAsync(new NutrientsResultPage(result));
            };
        }

        public async void SearchFood(object sender, System.EventArgs e)
        {
            var result = searchInput.Text;
            await Navigation.PushAsync(new NutrientsResultPage(result));
        }

       
    }
}