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
            CrossMTAdmob.Current.UserPersonalizedAds = true;
            CrossMTAdmob.Current.ComplyWithFamilyPolicies = true;
            CrossMTAdmob.Current.UseRestrictedDataProcessing = true;
            Sharpnado.Shades.Initializer.Initialize(false);
            Sharpnado.Tabs.Initializer.Initialize(true, false);
            DIPS.Xamarin.UI.Library.Initialize();

            //  MainPage = new MainPage();
            MainPage = new NavigationPage(new UserTabView());
        }
        public static string DatabaseLocation = string.Empty;
        public App(string databaseLocation)
        {
            InitializeComponent();
            CrossMTAdmob.Current.UserPersonalizedAds = true;
            CrossMTAdmob.Current.ComplyWithFamilyPolicies = true;
            CrossMTAdmob.Current.UseRestrictedDataProcessing = true;
            Sharpnado.Shades.Initializer.Initialize(false);
            Sharpnado.Tabs.Initializer.Initialize(true, false);
            //  MainPage = new MainPage();
            MainPage = new NavigationPage(new UserTabView());
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            InitializeComponent();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
