using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetails : ContentPage
    {
        RAWGQTSearch.Result GD;
        //private object gd;

        public GameDetails(object gd)
        {
            InitializeComponent();
            
            GD = (RAWGQTSearch.Result)gd;
            
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
           // collectionViewList.ItemsSource = GD;
            lbltest.Text = GD.Name;
        }
    }
}