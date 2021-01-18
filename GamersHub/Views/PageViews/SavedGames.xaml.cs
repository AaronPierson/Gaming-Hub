using GamersHub.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views.PageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Switcher.BindingContext = "hello";
            Switcher.SelectedIndex = 0;           
        }
    }
}