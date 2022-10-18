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
    public partial class ActionPage : ContentPage
    {
        private readonly ISyntaxHandler _syntaxHandler;
        private readonly string _command;
        private bool _handled;
        public ActionPage(string command)
        {
            InitializeComponent();
            _syntaxHandler = new SyntaxHandler(App.Current.MainPage as NavigationPage,main);
            Title = Resource.ActionTitle;
            _command = command;
        }
        protected override async void OnAppearing()
        {
            if (!_handled)
            {
                _handled = true;
                try
                {
                    await _syntaxHandler.Handle(_command);
                }
                catch (Exception e)
                {
                    await DisplayAlert(Resource.Error, Resource.InvalidSyntax, Resource.Ok);
                }
            }
            base.OnAppearing();
        }
    }
}