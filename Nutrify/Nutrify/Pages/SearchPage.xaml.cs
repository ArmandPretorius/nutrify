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
using Clarifai.API;
using Clarifai.DTOs.Inputs;
using System.IO;

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

        public async void FindFoodAI(string photopath)
        {
            findFoodIndicator.IsVisible = true;
            findFoodIndicator.IsRunning = true;
            SearchButton.IsVisible = false;
            searchingLabel.IsVisible = true;
            searchInput.IsVisible = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
                var client = new ClarifaiClient("1f32e3d0787341f7b82e2d10680e07ee");

                var res = await client.PublicModels.FoodModel
                 .Predict(new ClarifaiFileImage(File.ReadAllBytes(photopath)))
                .ExecuteAsync();

                var food = res.Get().Data[0];
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{food.Name}");
                Console.WriteLine($"{food.Value}");

                await Navigation.PushAsync(new NutrientsResultPage(food.Name));

                findFoodIndicator.IsVisible = false;
                findFoodIndicator.IsRunning = false;
                SearchButton.IsVisible = true;
                searchingLabel.IsVisible = false;
                searchInput.IsVisible = true;
            });
           
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
            //var aPpath = file.AlbumPath;

            //Get private path
            var path = file.Path;

            //await DisplayAlert("path", path, "Ok");

            FindFoodAI(path);

            //celebImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }

        private void RecipeBookButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecipeBookPage());

        }
    }
}