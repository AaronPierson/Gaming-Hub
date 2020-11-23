using GamersHub.ViewModels;
using RAWGQTDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetails : ContentPage
    {
        RAWGQT.Result SHGD;
        //private object gd;
        RAWGViewModel model = new RAWGViewModel();
        GamesDetails data = new GamesDetails();
        public GameDetails(object gd)
        {
            InitializeComponent();
            SHGD = (RAWGQT.Result)gd;
        }

        private async Task GetDetails()
        {
            data = await model.GetGameDetails(SHGD.Id.ToString());
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                await GetDetails();
                
                txtDescription.Text = data.DescriptionRaw.ToString();
                lblTitle.Text = data.Name;
                lblPlaytime.Text = "Estimate completion time: " + data.Playtime.ToString();
                imgGame.Source = data.BackgroundImage;
                lblRating.Text = "Rating: " + data.Rating.ToString();
                lblRatingsCount.Text = "Number of ratings: " + data.RatingsCount.ToString();
                lblRatingTop.Text = "Top score: " + data.RatingTop.ToString();
                lblRelease.Text = "Released Date: " + data.Released.ToString().Remove(9);
                //
                var color = SHGD.DominantColor.ToString().Remove(0, 3);
                //GamesLayout.BackgroundColor = ColorConverters.FromHex(color);
                //  GD.Stores[0].StoreStore.Name
                lstShortScreenshots.ItemsSource = SHGD.ShortScreenshots;
                lstGenres.ItemsSource = data.Genres;
                lstPlatform.ItemsSource = data.Platforms;
                lstStores.ItemsSource = data.Stores;
                // collectionViewList.ItemsSource = GD;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.ToString(), "OK");

            }



        }
    }
}