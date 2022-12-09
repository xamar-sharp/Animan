using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class EntryPropertyMapper : IPropertyMapper<Entry>
    {
        public async Task Map(AnimationContext ctx, Entry entry, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "IP":
                    entry.IsPassword = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "TXT":
                    entry.Text = raw;
                    break;
                case "P":
                    entry.Placeholder = raw;
                    break;
                case "PC":
                    entry.PlaceholderColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "SE":
                    entry.IsSpellCheckEnabled = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "ML":
                    entry.MaxLength = Convert.ToInt32(raw);
                    break;
                case "IR":
                    entry.IsReadOnly = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "KEY":
                    entry.Keyboard = App.ServiceLocator.KeyboardMapper.Format(raw);
                    break;
                case "S":
                    await entry.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await entry.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await entry.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    entry.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    entry.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    entry.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    entry.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await entry.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
