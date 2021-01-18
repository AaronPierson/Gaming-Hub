using DIPS.Xamarin.UI.Controls.Modality;
using DIPS.Xamarin.UI.Controls.Sheet;
using DIPS.Xamarin.UI.Extensions;
using GamersHub.Models;
using GamersHub.ViewModels;
using MarcTron.Plugin;
using RAWGQTDetail;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetails : ContentPage
    {
        public static RAWGQT.Result SHGD;
        RAWGViewModel model = new RAWGViewModel();
        GamesDetails data = new GamesDetails();
        AppAds ads = new AppAds();

        public static ObservableCollection<RAGWAchievements.Result> achievements { get; set; }

        public GameDetails(object gd)
        {
            InitializeComponent();           
            SHGD = (RAWGQT.Result)gd;        
        }
        public GameDetails(string id)
        {
            InitializeComponent();
            SHGD.Id = Convert.ToInt64(Convert.ToDecimal(id));
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
                ads.SetEvents();
                await GetDetails();
                BindingContext = data;
                Switcher.BindingContext = data;
                Switcher.SelectedIndex = 0;
                lblTitle.Text = data.Name;
                lblPlaytime.Text = "Estimate completion time: " + data.Playtime.ToString();
                imgGame.Source = data.BackgroundImage;
                if (!data.Metacritic.Equals(null))
                {
                    lblRating.Text = "Metacritic Score: " + data.Metacritic.Value.ToString();
                }
                else
                {
                    lblRelease.Text = "Score not yet available";
                }
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
            catch (Exception)
            {     
               // await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                await DisplayAlert("Alert", "Please check your internet connection", "OK");
            }
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
            ads.DisableEvents();
        }
        
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (Sheet.IsOpen)
            {
                Sheet.IsOpen = false;
            }
            else
            {
                Sheet.IsOpen = true;
            }          
        }

        private async void Playing_Clicked(object sender, EventArgs e)
        {
            bool successful = false;
            SQLViewModel sqlview = new SQLViewModel();
            successful = sqlview.SavePlayingGames(SHGD.Id.ToString());
            if(successful)
            await DisplayAlert("Alert", "Successfuly Added", "OK");
            else
                await DisplayAlert("Alert", "Adding was unsccessful", "OK");

        }

        private async void Finished_Clicked(object sender, EventArgs e)
        {
            bool successful = false;
            SQLViewModel sqlview = new SQLViewModel();
            successful = sqlview.SaveFinishedGames(SHGD.Id.ToString());
            if (successful)
                await DisplayAlert("Alert", "Successfuly Added", "OK");
            else
                await DisplayAlert("Alert", "Adding was unsccessful", "OK");
        }

        private async void Wanted_Clicked(object sender, EventArgs e)
        {
            bool successful = false;
            SQLViewModel sqlview = new SQLViewModel();
            successful = sqlview.SaveWantedGames(SHGD.Id.ToString());
            if (successful)
                await DisplayAlert("Alert", "Successfuly Added", "OK");
            else
                await DisplayAlert("Alert", "Adding was unsccessful", "OK");
        }
    }
}