using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class SyntaxHandler : ISyntaxHandler
    {
        private readonly NavigationPage _page;
        private readonly StackLayout _canvas;
        private readonly StringBuilder _temp;
        public SyntaxHandler(NavigationPage main, StackLayout canvas)
        {
            _page = main;
            _canvas = canvas;
            _temp = new StringBuilder(128);
        }
        public async Task Handle(string syntax)
        {
            AnimationContext ctx = new AnimationContext(_page, _canvas) { LastProperties = new Dictionary<string,string>(5) };
            for (int x = 0; x < syntax.Length; x++)
            {
                if (syntax[x] == SyntaxCenter.ElementNextSymbol)
                {
                    await App.ServiceLocator.ElementRecognizer.Recognize(ctx);
                    ctx.LastElement = null;
                    ctx.LastProperties.Clear();
                }
                else if(ctx.LastElement is null)
                {
                    _temp.Clear();
                    while(syntax[x] != SyntaxCenter.PropertiesStartSymbol && x < syntax.Length)
                    {
                        _temp.Append(syntax[x]);
                        x++;
                    }
                    ctx.LastElement = _temp.ToString();
                    _temp.Clear();
                }
                else if(ctx.LastProperty is null)
                {
                    while(syntax[x] != SyntaxCenter.ValueNextSymbol && x < syntax.Length)
                    {
                        _temp.Append(syntax[x]);
                        x++;
                    }
                    ctx.LastProperty = _temp.ToString();
                    _temp.Clear();
                }
                else if(ctx.LastValue is null)
                {
                    while (syntax[x] != SyntaxCenter.PropertyEndSymbol)
                    {
                        if (x + 1 >= syntax.Length || syntax[x+1] == SyntaxCenter.ElementNextSymbol)
                        {
                            _temp.Append(syntax[x]);
                            break;
                        }
                        else
                        {
                            _temp.Append(syntax[x]);
                            x++;
                        }
                    }
                    ctx.LastValue = _temp.ToString();
                    _temp.Clear();
                    ctx.LastProperties.Add(new KeyValuePair<string, string>(ctx.LastProperty, ctx.LastValue));
                    ctx.LastProperty = null;
                    ctx.LastValue = null;
                }
            }
            await App.ServiceLocator.ElementRecognizer.Recognize(ctx);
        }
    }
}
