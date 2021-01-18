using Sharpnado.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamersHub.Views.PageViews.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Achievements : ContentView, IAnimatableReveal
    {
        public Achievements()
        {
            InitializeComponent();
        }

        public bool Animate { get; set; }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            lstAchievements.ItemsSource = GameDetails.achievements;

        }
    }
}