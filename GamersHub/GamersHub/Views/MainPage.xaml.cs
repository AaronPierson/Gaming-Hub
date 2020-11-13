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
        RAWGViewModel model = new RAWGViewModel();
        public ObservableCollection<Result> Games { get; set; }
        private async void ContentPage_Appearing(object sender, EventArgs e)
        {

            try
            {
                Games = await model.GetAllGamesAsync();
                var a = Games[1].Platforms[0].Platform.Name;
                collectionViewList.ItemsSource = Games;
            }catch(Exception ex)
            {
               
            }
             
          //  Games[0].BackgroundImage
           // Games[0].ShortScreenshots[0].Image.
          
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                
                
                //collectionViewList.ItemsSource = Games;
                //var a = Games[1].ParentPlatforms[0].Platform.Name;
                collectionViewList.ItemsSource = await model.SearchGamesAsync(e.NewTextValue);
                //lblCount.Text = RAWGViewModel.PageCount;
                // await Task.Delay(2000);
            }
            catch (Exception ex)
            {

            }
           
        }

        private async void btnNextPage_Clicked(object sender, EventArgs e)
        {
            collectionViewList.ItemsSource = await model.SearchNextAsync();
        }

        private async void collectionViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  var Gamedetails = new GameDetails();
            var gd = e.CurrentSelection[0];
            await Navigation.PushAsync(new GameDetails(gd));
           
           // Application.Current.MainPage.Navigation.PushAsync(GameDetails);

        }

        //  Games = await model.GetAllGamesAsync();
        //collectionViewList.ItemsSource = Games;

    }

 
}
