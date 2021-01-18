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
    public partial class WantView : ContentView
    {
        public WantView()
        {
            InitializeComponent();
        }

        RAWGViewModel viewModel = new RAWGViewModel();
        public bool Animate { get; set; }

        protected override async void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                List<RAWGQTDetail.GamesDetails> gd = new List<RAWGQTDetail.GamesDetails>();
                conn.CreateTable<WantGames>();
                var game = conn.Table<WantGames>().ToList();
                foreach (var item in game)
                {
                    gd.Add(await viewModel.GetGameDetails(item.GameId));
                }
                wantGamesCV.ItemsSource = gd;
            }
        }

        private async void wantGamesCV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var gd = (RAWGQTDetail.GamesDetails)e.CurrentSelection[0];
                await Navigation.PushAsync(new GameDetails(gd.Id.ToString()));
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
            }
        }
    }
}