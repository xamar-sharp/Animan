using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class ImagePropertyMapper : IPropertyMapper<Image>
    {
        public async Task Map(AnimationContext ctx, Image img, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await img.TranslateTo(point.X, point.Y);
                    break;
                case "RL":
                    await img.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "S":
                    img.Source = App.ServiceLocator.ImageFormatter.Format(raw);
                    break;
                case "HR":
                    img.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    img.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    img.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    img.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "SL":
                    await img.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "F":
                    await img.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "A":
                    img.Aspect = App.ServiceLocator.AspectMapper.Format(raw);
                    break;
                default:
                    await img.ScaleYTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
            }
            await Task.Yield();
        }
    }
}