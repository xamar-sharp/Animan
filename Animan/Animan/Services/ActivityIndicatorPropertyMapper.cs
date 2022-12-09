using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class ActivityIndicatorPropertyMapper : IPropertyMapper<ActivityIndicator>
    {
        public async Task Map(AnimationContext ctx, ActivityIndicator indicator, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "IR":
                    indicator.IsRunning = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "C":
                    indicator.Color = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "S":
                    await indicator.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await indicator.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await indicator.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    indicator.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    indicator.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    indicator.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    indicator.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await indicator.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
