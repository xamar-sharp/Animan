using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class EnvironmentPropertyMapper : IPropertyMapper<StackLayout>
    {
        public async Task Map(AnimationContext ctx, StackLayout layout, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "BC":
                    layout.BackgroundColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "B":
                    layout.Background = App.ServiceLocator.LinearGradientMapper.Format(raw);
                    break;
                case "NBC":
                    ctx.MainPage.BarBackgroundColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "NTC":
                    ctx.MainPage.BarTextColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "NB":
                    ctx.MainPage.BarBackground = App.ServiceLocator.LinearGradientMapper.Format(raw);
                    break;
                case "O":
                    layout.Orientation = App.ServiceLocator.StackOrientationFormatter.Format(raw);
                    break;
                default:
                    layout.Spacing = Convert.ToInt32(raw);
                    break;
            }
            await Task.Yield();
        }
    }
}
