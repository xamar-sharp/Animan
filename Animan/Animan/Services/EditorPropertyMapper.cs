using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace Animan.Services
{
    public sealed class EditorPropertyMapper : IPropertyMapper<Editor>
    {
        public async Task Map(AnimationContext ctx, Editor editor, string propertyName)
        {
            var raw = ctx.LastProperties[propertyName];
            switch (propertyName)
            {
                case "AS":
                    editor.AutoSize = App.ServiceLocator.AutoSizeFormatter.Format(raw);
                    break;
                case "TXT":
                    editor.Text = raw;
                    break;
                case "P":
                    editor.Placeholder = raw;
                    break;
                case "PC":
                    editor.PlaceholderColor = App.ServiceLocator.ColorMapper.Format(raw);
                    break;
                case "SE":
                    editor.IsSpellCheckEnabled = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "ML":
                    editor.MaxLength = Convert.ToInt32(raw);
                    break;
                case "IR":
                    editor.IsReadOnly = App.ServiceLocator.BooleanFormatter.Format(raw);
                    break;
                case "KEY":
                    editor.Keyboard = App.ServiceLocator.KeyboardMapper.Format(raw);
                    break;
                case "S":
                    await editor.RelScaleTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "R":
                    await editor.RelRotateTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                case "T":
                    var point = App.ServiceLocator.PositionMapper.Format(raw);
                    await editor.TranslateTo(point.X, point.Y);
                    break;
                case "HR":
                    editor.HeightRequest = Convert.ToInt32(raw);
                    break;
                case "WR":
                    editor.WidthRequest = Convert.ToInt32(raw);
                    break;
                case "VO":
                    editor.VerticalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "HO":
                    editor.HorizontalOptions = App.ServiceLocator.LayoutOptionsFormatter.Format(raw);
                    break;
                case "F":
                    await editor.FadeTo(App.ServiceLocator.DoubleFormatter.Format(raw));
                    break;
                default:
                    break;
            }
            await Task.Yield();
        }
    }
}
