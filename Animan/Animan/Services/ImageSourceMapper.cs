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
            if (raw.Contains("://"))
            {
                return ImageSource.FromUri(new Uri(raw));
            }
            byte[] bytes;
            try
            {
                bool res = System.IO.File.Exists(raw);
                bytes = System.IO.File.ReadAllBytes(raw);
            }
            catch(Exception ex)
            {
                bytes = null;
            }
            return ImageSource.FromStream(() => new System.IO.MemoryStream(bytes));
        }
    }
}
