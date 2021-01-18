using GamersHub.Models;
using GamersHub.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views.PageViews.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayingView : ContentView
    {
        public PlayingView()
        {
            InitializeComponent();
        }

        public bool Animate { get; set; }
        RAWGViewModel viewModel = new RAWGViewModel();

        protected override async void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                List<RAWGQTDetail.GamesDetails> gd = new List<RAWGQTDetail.GamesDetails>();
                conn.CreateTable<PlayingGames>();
                var game = conn.Table<PlayingGames>().ToList();
                foreach (var item in game)
                {
                    gd.Add(await viewModel.GetGameDetails(item.GameId));

                }
                playingGamesCV.ItemsSource = gd;
            }
        }

        private async void playingGamesCV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var gd = e.CurrentSelection[0];
                await Navigation.PushAsync(new GameDetails(gd));
            }
            catch (Exception)
            {
                // await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                //await DisplayAlert("Alert", "Please check your internet connection", "OK");
            }
        }
    }
}