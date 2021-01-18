using GamersHub.Models;
using GamersHub.ViewModels;
using RAWGQT;
using SQLite;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        RAWGViewModel RAWGVM = new RAWGViewModel();
        public ObservableCollection<Result> Games { get; set; }
        private bool initialized;

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (initialized == false)
            {
                try
                {
                    Games = await RAWGVM.GetUpComingGamesAsync();
                    cvUpComing.ItemsSource = Games;
                    //
                    Games = await RAWGVM.GetLatestesGamesAsync();
                    cvLatest.ItemsSource = Games;
                    initialized = true;
                }
                catch (Exception)
                {
                   // await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                    await DisplayAlert("Alert", "Please check your internet connection", "OK");
                }
            }

           
        }



        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var gd = e.CurrentSelection[0];
                await Navigation.PushAsync(new GameDetails(gd));
            }
            catch (Exception)
            {
                // await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                await DisplayAlert("Alert", "Please check your internet connection", "OK");
            }
        }
    }
}