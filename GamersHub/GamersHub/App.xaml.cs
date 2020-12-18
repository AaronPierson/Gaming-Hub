using GamersHub.Views;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Sharpnado.Shades.Initializer.Initialize(false);
            Sharpnado.Tabs.Initializer.Initialize(true, false);
            //  MainPage = new MainPage();
            MainPage = new NavigationPage(new UserTabView());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
