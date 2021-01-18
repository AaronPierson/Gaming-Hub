using System;
using Android.Gms.Ads;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms;

namespace GamersHub.Droid
{
    [Activity(Label = "GamersHub", Icon = "@drawable/Icon48", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Forms.SetFlags("SwipeView_Experimental");

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Test: MobileAds.Initialize(this, " ca­-app-pub-­3940256099942544~3347511713");
            DIPS.Xamarin.UI.Android.Library.Initialize();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            Rg.Plugins.Popup.Popup.Init(this);
            MobileAds.Initialize(this, "ca-app-pub-1387996564780038~2222145561");
            string dbname = "gamers_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbname);
            LoadApplication(new App(fullPath));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}