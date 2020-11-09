using GamersHub.ViewModels;
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
              Games = await model.GetNewGamesAsync();
            var a = Games[1].Platforms[0].Platform.Name;
            collectionViewList.ItemsSource = Games;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            collectionViewList.ItemsSource = Games;
            //var a = Games[1].ParentPlatforms[0].Platform.Name;
            collectionViewList.ItemsSource = await model.SearchGamesAsync(e.NewTextValue.ToString());
            // await Task.Delay(2000);
        }

        //  Games = await model.GetNewGamesAsync();
        //collectionViewList.ItemsSource = Games;

    }
}
