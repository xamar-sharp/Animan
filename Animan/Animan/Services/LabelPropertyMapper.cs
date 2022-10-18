using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class LabelPropertyMapper : IPropertyMapper<Label>
    {
        public async Task Map(AnimationContext ctx, Label label, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await label.TranslateTo(point.X, point.Y);
                    break;
                case "RL":
                    await label.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "FS":
                    if (raw.StartsWith("N'"))
                    {
                        label.FontSize = Device.GetNamedSize(App.ServiceLocator.NamedSizeMapper.Format(raw),typeof(Label));
                    }
                    else
                    {
                        label.FontSize = Convert.ToInt32(raw);
                    }
                    break;
                case "SL":
                    await label.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "BC":
                    label.BackgroundColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "TXT":
                    label.Text = raw;
                    break;
                case "TC":
                    label.TextColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "F":
                    await label.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    label.FontAttributes = App.ServiceLocator.FontAttributesMapper.Format(raw);
                    break;
            }
            await Task.Yield();
        }
    }
}
