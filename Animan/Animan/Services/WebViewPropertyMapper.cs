using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class WebViewPropertyMapper : IPropertyMapper<WebView>
    {
        public async Task Map(AnimationContext ctx, WebView webView, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "S":
                    if (raw.StartsWith("html'")) { webView.Source = new HtmlWebViewSource() { Html = raw.Substring(6) }; } else { webView.Source = new UrlWebViewSource() { Url = raw.Substring(6) }; }
                    break;
                case "HR":
                    webView.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    webView.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    webView.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    webView.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await webView.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
