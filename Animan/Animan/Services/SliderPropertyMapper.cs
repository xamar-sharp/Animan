using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class SliderPropertyMapper : IPropertyMapper<Slider>
    {
        public async Task Map(AnimationContext ctx, Slider slider, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            slider.Minimum = 0;
            switch (propertyName)
            {
                case "MAX":
                    slider.Maximum = App.ServiceLocator.DoubleFormatter.Format(raw);
                    break;
                case "MAXC":
                    slider.MaximumTrackColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "MINC":
                    slider.MinimumTrackColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "THC":
                    slider.ThumbColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "V":
                    slider.Value = App.ServiceLocator.DoubleFormatter.Format(raw);
                    break;
                case "S":
                    await slider.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await slider.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await slider.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    slider.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    slider.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    slider.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    slider.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await slider.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
