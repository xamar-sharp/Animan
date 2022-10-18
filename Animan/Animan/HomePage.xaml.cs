using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animan.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            mainLabel.Text = Resource.Welcome;
            cmd.Placeholder = Resource.EnterCommand;
            helpLink.Text = Resource.HelpLink;
        }

        private async void cmd_Completed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionPage(cmd.Text));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }
    }
}