using GamersHub.ViewModels;
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
        RAWGQT.Result GD;
        bool usingSearchType;
        //private object gd;
        RAWGViewModel model = new RAWGViewModel();
       
        public GameDetails(object gd)
        {
            InitializeComponent();
          //  print(a.GetType() == typeof(Animal))
          //check type
            if(gd.GetType() == typeof(RAWGQT.Result))
            {
                SHGD = (RAWGQT.Result)gd;
                usingSearchType = true;
             //   var data = model.GetGameDetails(GD.Id.ToString());
                // lblTitle.Text = data.Result.Description;
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if(usingSearchType == true)
            {
                txtDescription.Text = SHGD.Name;
                lblTitle.Text = SHGD.Name;
                lblPlaytime.Text = "Estimate completion time: " + SHGD.Playtime.ToString();
                imgGame.Source = SHGD.BackgroundImage;
                lblRating.Text = "Rating: " + SHGD.Rating.ToString();
                lblRatingsCount.Text = "Number of ratings: " + SHGD.RatingsCount.ToString();
                lblRatingTop.Text = "Top score: " + SHGD.RatingTop.ToString();
                lblRelease.Text = "Released Date: " + SHGD.Released.ToString().Remove(9);
                //
                var color = SHGD.DominantColor.ToString().Remove(0, 3);
                //GamesLayout.BackgroundColor = ColorConverters.FromHex(color);
                //  GD.Stores[0].StoreStore.Name
                lstShortScreenshots.ItemsSource = SHGD.ShortScreenshots;
                lstGenres.ItemsSource = SHGD.Genres;
                lstPlatform.ItemsSource = SHGD.Platforms;
                lstStores.ItemsSource = SHGD.Stores;

            }
           
           // collectionViewList.ItemsSource = GD;
            
        }
    }
}