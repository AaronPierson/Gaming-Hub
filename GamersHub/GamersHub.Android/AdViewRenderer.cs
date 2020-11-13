using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Gms.Ads;
using Xamarin.Forms.Platform.Android;
using GamersHub.Controls;
using GamersHub.Droid;

[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace GamersHub.Droid
{
    [Obsolete]
    public class AdViewRenderer : ViewRenderer<AdControlView, AdView>
    {

        public AdViewRenderer(Context context) : base(context)
        {

        }   

        string adUnitID = "ca-app-pub-1387996564780038/4737123107";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        AdView CreateAdView()
        {
            if (adView != null)
                return adView;

            adView = new AdView(Forms.Context)
            {
                AdSize = adSize,
                AdUnitId = adUnitID
             };
           
            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest.Builder().Build());
            return adView;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);

            if (Control == null && e.NewElement != null)
            {
               SetNativeControl( CreateAdView());
                SetNativeControl(adView);
            }
        }
    }
}