using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class SwitchPropertyMapper : IPropertyMapper<Switch>
    {
        public async Task Map(AnimationContext ctx, Switch switcher, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "THC":
                    switcher.ThumbColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "OC":
                    switcher.OnColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "IC":
                    switcher.IsToggled = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "S":
                    await switcher.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await switcher.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await switcher.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    switcher.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    switcher.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    switcher.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    switcher.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await switcher.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
