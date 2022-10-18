using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Animan.Models;
namespace Animan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        public ObservableCollection<HelpModel> Items { get; set; }
        public HelpPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<HelpModel>(App.ServiceLocator.HelpProvider.Provide());
            Title = Resource.HelpTitle;
            this.BindingContext = this;
        }
    }
}