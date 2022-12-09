using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class CheckBoxPropertyMapper : IPropertyMapper<CheckBox>
    {
        public async Task Map(AnimationContext ctx, CheckBox box, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "IC":
                    box.IsChecked = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "C":
                    box.Color = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "S":
                    await box.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await box.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await box.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    box.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    box.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    box.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    box.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await box.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
