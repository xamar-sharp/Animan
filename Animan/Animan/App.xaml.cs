using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Animan.Services;
using Animan.Dependencies;
namespace Animan
{
    public partial class App : Application
    {
        public static ServiceLocator ServiceLocator { get; }
        public App()
        {
            var markup = new MarkupExtensions.TimeOfYear();
            InitializeComponent();
            markup.Name = "ContentPage";
            var navig = new NavigationPage(new HomePage() {Title=Resource.HomeTitle, Style = markup.ProvideValue(null) as Style});
            markup.Name = "NavigationPage";
            navig.Style = markup.ProvideValue(null) as Style;
            MainPage = navig;
        }
        static App()
        {
            ServiceLocator = new ServiceLocator();
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
