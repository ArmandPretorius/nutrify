using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;

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

        public void FindFoodAI(string photopath)
        {

        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                Directory = "Nutrify",
                SaveToAlbum = true,
            });

            if (file == null)
                return;

            //Get the public album path
            var aPpath = file.AlbumPath;

            //Get private path
            var path = file.Path;

            await DisplayAlert("path", path, "Ok");

            FindFoodAI(path);

            //celebImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }
    }
}