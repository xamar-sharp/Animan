using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class ImageSourceMapper:IValueFormatter<ImageSource>
    {
        public ImageSource Format(string raw)
        {
            if (Uri.IsWellFormedUriString(raw,UriKind.Absolute))
            {
                return ImageSource.FromUri(new Uri(raw));
            }
            return ImageSource.FromFile(raw);
        }
    }
}
