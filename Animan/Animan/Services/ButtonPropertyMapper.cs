using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class ButtonPropertyMapper : IPropertyMapper<Button>
    {
        public async Task Map(AnimationContext ctx, Button button, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "BBC":
                    button.BorderColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "BR":
                    button.CornerRadius = Convert.ToInt32(raw);
                    break;
                case "BW":
                    button.BorderWidth = App.ServiceLocator.DoubleFormatter.Format(raw);
                    break;
                case "BC":
                    button.BackgroundColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "TXT":
                    button.Text = raw;
                    break;
                case "TC":
                    button.TextColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "S":
                    await button.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await button.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await button.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    button.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    button.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    button.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    button.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await button.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }

}
