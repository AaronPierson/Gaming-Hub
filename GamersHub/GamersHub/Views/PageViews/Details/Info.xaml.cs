using GamersHub.ViewModels;
using GamersHub.Views.PopUps;
using RAWGQT;
using Sharpnado.Tabs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views.PageViews.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Info : ContentView, IAnimatableReveal
    {
        //RAWGViewModel RAWGVM = new RAWGViewModel();
        //GameDetails GameD = new GameDetails();
        public Info()
        {
            InitializeComponent();
        }

        public bool Animate { get; set; }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            lstShortScreenshots.ItemsSource = GameDetails.SHGD.ShortScreenshots;

        }

        private async void lstShortScreenshots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                 var url = (RAWGQT.ShortScreenshot)e.CurrentSelection[0];
                await Navigation.PushAsync(new ScreenShotPop(url.Image.ToString()));
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Alert", "Please check your internet connection" + ex.ToString(), "OK");
                // await DisplayAlert("Alert", "Please check your internet connection", "OK");

            }
        }
    }
}