using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
namespace Animan.MarkupExtensions
{
    [ContentProperty("Direction")]
    public sealed class Asset:IMarkupExtension
    {
        private static readonly TimeOfYear _helper;
        static Asset()
        {
            _helper = new TimeOfYear();
        }
        public bool Direction { get; set; }
        public object ProvideValue(IServiceProvider provider)
        {
            return ImageSource.FromFile($"{_helper.GetMonth().ToLower()}_{(Direction ? "up" : "down")}");
        }
    }
}
