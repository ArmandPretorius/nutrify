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
    public partial class NotFoundPage : ContentPage
    {
        public NotFoundPage(string errorBody, string backButton)
        {
            InitializeComponent();

            errorMessage.Text = errorBody;
            backButtonColor.Source = backButton;
        }

        private void Back_Function_Clicked(object sender, EventArgs e)
        {
                Navigation.PopToRootAsync();
        }
    }
}