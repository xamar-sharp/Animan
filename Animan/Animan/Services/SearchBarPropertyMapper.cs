using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class SearchBarPropertyMapper : IPropertyMapper<SearchBar>
    {
        public async Task Map(AnimationContext ctx, SearchBar bar, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "CC":
                    bar.CancelButtonColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "TXT":
                    bar.Text = raw;
                    break;
                case "P":
                    bar.Placeholder = raw;
                    break;
                case "PC":
                    bar.PlaceholderColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "SE":
                    bar.IsSpellCheckEnabled = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "ML":
                    bar.MaxLength = Convert.ToInt32(raw);
                    break;
                case "IR":
                    bar.IsReadOnly = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "KEY":
                    bar.Keyboard = App.ServiceLocator.KeyboardMapper.Format(raw);
                    break;
                case "S":
                    await bar.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await bar.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await bar.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    bar.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    bar.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    bar.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    bar.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await bar.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
