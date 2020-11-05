using GamersHub.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GamersHub
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new RAWGViewModel();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
          
        }
    }
}
