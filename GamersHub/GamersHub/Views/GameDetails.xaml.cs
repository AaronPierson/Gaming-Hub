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
        RAWGQTSearch.Result SHGD;
        RAWGQT.Result GD;
        bool usingSearchType;
        //private object gd;
       
        public GameDetails(object gd)
        {
            InitializeComponent();
          //  print(a.GetType() == typeof(Animal))
          //check type
            if(gd.GetType() == typeof(RAWGQTSearch.Result))
            {
                SHGD = (RAWGQTSearch.Result)gd;
                usingSearchType = true;
            }
            else
            {
                usingSearchType = false;
                GD = (RAWGQT.Result)gd;
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if(usingSearchType == true)
            {
                lblTitle.Text = SHGD.Name;
                imgGame.Source = SHGD.BackgroundImage;
               
              
               
            }
            else
            {
                lblTitle.Text = GD.Name;
                lblPlaytime.Text = "Playtime: " + GD.Playtime.ToString();
                imgGame.Source = GD.BackgroundImage;
                lblRating.Text = "Rating: " + GD.Rating.ToString();
                lblRatingsCount.Text = "Number of ratings: " + GD.RatingsCount.ToString();
                lblRatingTop.Text = "Top score: " + GD.RatingTop.ToString();
                lblRelease.Text = "Released Date: " + GD.Released.ToString();
                //
                var color = GD.DominantColor.ToString().Remove(0,3);
                //GamesLayout.BackgroundColor = ColorConverters.FromHex(color);
              //  GD.Stores[0].StoreStore.Name
                lstShortScreenshots.ItemsSource = GD.ShortScreenshots;
                lstGenres.ItemsSource = GD.Genres;
                lstPlatform.ItemsSource = GD.Platforms;
                lstStores.ItemsSource = GD.Stores;
            }
           // collectionViewList.ItemsSource = GD;
            
        }
    }
}