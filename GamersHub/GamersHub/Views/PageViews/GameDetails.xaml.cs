using GamersHub.ViewModels;
using GamersHub.Views.PopUps;
using RAGWAchievements;
using RAWGQT;
using RAWGQTDetail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static RAWGQT.Result SHGD;
        //private object gd;
        RAWGViewModel model = new RAWGViewModel();
        GamesDetails data = new GamesDetails();
        public static ObservableCollection<RAGWAchievements.Result> achievements { get; set; }

        public GameDetails(object gd)
        {
            InitializeComponent();
            SHGD = (RAWGQT.Result)gd;
        }

        private async Task GetDetails()
        {
            data = await model.GetGameDetails(SHGD.Id.ToString());
            achievements = await model.GetAchievementsAsync(SHGD.Id.ToString());
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                await GetDetails();
                Switcher.BindingContext = data;
                Switcher.SelectedIndex = 0;
                lblTitle.Text = data.Name;
                lblPlaytime.Text = "Estimate completion time: " + data.Playtime.ToString();
                imgGame.Source = data.BackgroundImage;
                lblRating.Text = "Rating: " + data.Rating.ToString() + " / 5";
                if (!data.Released.Equals(null))
                {
                    lblRelease.Text = "Released Date: " + data.Released.ToString().Remove(9);
                }
                else
                {
                    lblRelease.Text = "Released Date: TBA";
                }
                //
                var color = SHGD.DominantColor.ToString().Remove(0, 3);
                //GamesLayout.BackgroundColor = ColorConverters.FromHex(color);
               // lstShortScreenshots.ItemsSource = SHGD.ShortScreenshots;
                // collectionViewList.ItemsSource = GD;
            }
            catch (Exception ex)
            {     
               // await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                await DisplayAlert("Alert", "Please check your internet connection", "OK");
            }

        }

        private async void lstShortScreenshots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               // var url = (RAWGQT.ShortScreenshot)e.CurrentSelection[0];
                //await Navigation.PushAsync(new ScreenShotPop(url.Image.ToString()));
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
               // await DisplayAlert("Alert", "Please check your internet connection", "OK");

            }


        }
    }
}