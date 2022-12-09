using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class SimpleElementRecognizer : IElementRecognizer
    {
        public async Task ForAllCanvasPropertiesAsync(AnimationContext ctx)
        {
            foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
            {
                await App.ServiceLocator.EnvironmentPropertyMapper.Map(ctx, ctx.Canvas, el);
            }
        }
        public async Task ForAllLabelPropertiesAsync(AnimationContext ctx,Label target)
        {
            foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
            {
                await App.ServiceLocator.LabelPropertyMapper.Map(ctx, target, el);
            }
        }
        public async Task Recognize(AnimationContext ctx)
        {
            switch (ctx.LastElement)
            {
                case "Env":
                    await ForAllCanvasPropertiesAsync(ctx);
                    break;
                case "Lab":
                    Label label = new Label();
                    ctx.Canvas.Children.Add(label);
                    await ForAllLabelPropertiesAsync(ctx,label);
                    break;
                case "Img":
                    Image img = new Image();
                    ctx.Canvas.Children.Add(img);
                    foreach (var el in ctx.LastProperties.Keys.Select(key=>key.ToUpper()))
                    {
                        await App.ServiceLocator.ImagePropertyMapper.Map(ctx, img, el);
                    }
                    break;
                case "Chk":
                    CheckBox box = new CheckBox();
                    ctx.Canvas.Children.Add(box);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.CheckBoxPropertyMapper.Map(ctx, box, el);
                    }
                    break;
                case "ProBar":
                    ProgressBar bar = new ProgressBar();
                    ctx.Canvas.Children.Add(bar);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.ProgressBarPropertyMapper.Map(ctx, bar, el);
                    }
                    break;
                case "Slid":
                    Slider slider = new Slider();
                    ctx.Canvas.Children.Add(slider);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.SliderPropertyMapper.Map(ctx, slider, el);
                    }
                    break;
                case "Sebar":
                    SearchBar sebar = new SearchBar();
                    ctx.Canvas.Children.Add(sebar);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.SearchBarPropertyMapper.Map(ctx, sebar, el);
                    }
                    break;
                case "But":
                    Button button = new Button();
                    ctx.Canvas.Children.Add(button);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.ButtonPropertyMapper.Map(ctx, button, el);
                    }
                    break;
                case "Ent":
                    Entry entry = new Entry();
                    ctx.Canvas.Children.Add(entry);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.EntryPropertyMapper.Map(ctx, entry, el);
                    }
                    break;
                case "Edit":
                    Editor editor = new Editor();
                    ctx.Canvas.Children.Add(editor);
                    foreach (var el in ctx.LastProperties.Keys.Select(key => key.ToUpper()))
                    {
                        await App.ServiceLocator.EditorPropertyMapper.Map(ctx, editor, el);
                    }
                    break;
            }
        }
    }
}
