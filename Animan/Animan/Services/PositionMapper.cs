using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class PositionMapper : IValueFormatter<Point>
    {
        public Point Format(string raw)
        {
            string[] seps = raw.Split(SyntaxCenter.PointSeparator);
            return new Point(Convert.ToInt32(seps[0]), Convert.ToInt32(seps[1]));
        }
    }
}
