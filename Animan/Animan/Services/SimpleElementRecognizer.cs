using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class SimpleElementRecognizer : IElementRecognizer
    {
        public async Task ForAllCanvasPropertiesAsync(AnimationContext ctx)
        {
            foreach (var el in ctx.LastProperties.Keys)
            {
                await App.ServiceLocator.EnvironmentPropertyMapper.Map(ctx, ctx.Canvas, el);
            }
        }
        public async Task ForAllLabelPropertiesAsync(AnimationContext ctx,Label target)
        {
            foreach (var el in ctx.LastProperties.Keys)
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
                    foreach (var el in ctx.LastProperties.Keys)
                    {
                        await App.ServiceLocator.ImagePropertyMapper.Map(ctx, img, el);
                    }
                    break;
            }
        }
    }
}
