using GamersHub.ViewModels;
using GamersHub.Views;
using RAWGQT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GamersHub
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           // BindingContext = new MainPage();
          
        }
        RAWGViewModel RAWGVM = new RAWGViewModel();
        public ObservableCollection<Result> Games { get; set; }
        private async void ContentPage_Appearing(object sender, EventArgs e)
        {

            try
            {
                Games = await RAWGVM.GetAllGamesAsync();
                var a = Games[1].Platforms[0].PlatformPlatform.Name;
                collectionViewList.ItemsSource = Games;

               

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.ToString(), "OK");

            }

           

        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SearchBar searchBar = (SearchBar)sender;
               
                //collectionViewList.ItemsSource = Games;
                //var a = Games[1].ParentPlatforms[0].Platform.Name;
                collectionViewList.ItemsSource = await RAWGVM.SearchGamesAsync(searchBar.Text); 
                //collectionViewList.ItemsSource = await RAWGVM.SearchGamesAsync(e.NewTextValue);
                //lblCount.Text = RAWGViewModel.PageCount;
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.ToString(), "OK");
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

                // Application.Current.MainPage.Navigation.PushAsync(GameDetails);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.ToString(), "OK");

            }
            //  var Gamedetails = new GameDetails();


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
                //collectionViewList.ItemsSource = Games;
                //var a = Games[1].ParentPlatforms[0].Platform.Name;
                collectionViewList.ItemsSource = await RAWGVM.SearchGamesAsync(searchBar.Text);
                //lblCount.Text = RAWGViewModel.PageCount;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.ToString(), "OK");
            }
        }





        //  Games = await model.GetAllGamesAsync();
        //collectionViewList.ItemsSource = Games;

    }

 
}
