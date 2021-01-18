using GamersHub.ViewModels;
using GamersHub.Views;
using RAWGQT;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace GamersHub
{
    public partial class SearchView : ContentPage
    {
        public SearchView()
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
                await LoadGames();
                collectionViewList.ItemsSource = Games;
                //txtMeta.Text = Games[0].Metacritic.Value.ToString();
                initialized = true;
            }
        }

        private async Task LoadGames()
        {
            try
            {
                Games = await RAWGVM.GetAllGamesAsync();
                //Games[0].Clip.Video;
                //collectionViewList.ItemsSource = Games;
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Alert", "Please check your internet connection", "OK");
                await DisplayAlert("Alert", ex.ToString(), "OK");
            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SearchBar searchBar = (SearchBar)sender;
                collectionViewList.ItemsSource = await RAWGVM.SearchGamesAsync(searchBar.Text);              
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Alert", "Please check your internet connection", "OK");
                await DisplayAlert("Alert", ex.ToString(), "OK");

                //await DisplayAlert("Alert", "Please check your internet connection" + ex.Message, "OK");
            }

        }

        private async void btnNextPage_Clicked(object sender, EventArgs e)
        {          
            collectionViewList.ItemsSource = await RAWGVM.SearchNextAsync();
        }

        private async void collectionViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var gd = e.CurrentSelection[0];
                await Navigation.PushAsync(new GameDetails(gd));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
               // await DisplayAlert("Alert", "Please check your internet connection", "OK");

            }
        }

        private async void btnBackPage_Clicked(object sender, EventArgs e)
        {
            collectionViewList.ItemsSource = await RAWGVM.SearchPerviousAsync();
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                SearchBar searchBar = (SearchBar)sender;
                collectionViewList.ItemsSource = await RAWGVM.SearchGamesAsync(searchBar.Text);
            }
            catch (Exception)
            {
               // await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                await DisplayAlert("Alert", "Please check your internet connection", "OK");

            }
        }
    }

 
}
