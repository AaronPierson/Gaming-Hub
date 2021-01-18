using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamersHub.Models
{
     public class AppAds
    {

       private static bool  _shouldSetEvents = true;

       public void SetEvents()
        {
            if (_shouldSetEvents)
            {
                _shouldSetEvents = false;

                CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-1387996564780038/8428059286");
                CrossMTAdmob.Current.OnInterstitialLoaded += Current_OnInterstitialLoaded;
                CrossMTAdmob.Current.OnInterstitialOpened += Current_OnInterstitialOpened;
                CrossMTAdmob.Current.OnInterstitialClosed += Current_OnInterstitialClosed;
            }
        }

        private void Current_OnInterstitialClosed(object sender, EventArgs e)
        {
            // Debug.WriteLine("2OnInterstitialClosed");
        }

        private void Current_OnInterstitialOpened(object sender, EventArgs e)
        {
            //Debug.WriteLine("2OnInterstitialOpened");
        }

        private void Current_OnInterstitialLoaded(object sender, EventArgs e)
        {
            // Debug.WriteLine("2OnInterstitialLoaded");
        }

        private void LoadInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-1387996564780038/8428059286");
        }

        private void ShowInterstitial_OnClicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
        }

        private void IsLoadedInterstitial_OnClicked(object sender, EventArgs e)
        {
            //myLabel.Text = CrossMTAdmob.Current.IsInterstitialLoaded().ToString();
        }

        public void DisableEvents()
        {
            _shouldSetEvents = true;

            CrossMTAdmob.Current.OnInterstitialLoaded -= Current_OnInterstitialLoaded;
            CrossMTAdmob.Current.OnInterstitialOpened -= Current_OnInterstitialOpened;
            CrossMTAdmob.Current.OnInterstitialClosed -= Current_OnInterstitialClosed;
        }
    }
}
