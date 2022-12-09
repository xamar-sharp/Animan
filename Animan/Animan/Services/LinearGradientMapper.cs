using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class LinearGradientMapper : IValueFormatter<Brush>
    {
        private readonly IValueFormatter<Color> _colorMapper;
        public LinearGradientMapper(IValueFormatter<Color> colorMapper)
        {
            _colorMapper = colorMapper;
        }
        public Brush Format(string raw)
        {
            string[] seps = raw.Split(SyntaxCenter.LinearGradientSeparator);
            LinearGradientBrush brush = new LinearGradientBrush() { GradientStops = { } };
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 0);
            for (int x = 0; x < seps.Length; x++)
            {
                var val = Convert.ToSingle((x) / (double)seps.Length);
                brush.GradientStops.Add(new GradientStop() { Offset = val, Color = _colorMapper.Format(seps[x]) });
            }
            return brush;
        }
    }
}
