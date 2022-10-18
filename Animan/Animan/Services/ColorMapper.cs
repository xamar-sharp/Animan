using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class ColorMapper : IValueFormatter<Color>
    {
        private static readonly IDictionary<string, Color> _map;
        static ColorMapper()
        {
            _map = new Dictionary<string, Color>(8)
            {
                [Resource.Black] = Color.Black,
                [Resource.White] = Color.White,
                [Resource.Orange] = Color.Orange,
                [Resource.OrangeRed] = Color.OrangeRed,
                [Resource.Purple] = Color.Purple,
                [Resource.DarkOrchid] = Color.DarkOrchid,
                [Resource.MediumOrchid] = Color.MediumOrchid,
                [Resource.Gray] = Color.Gray,
                [Resource.Yellow] = Color.Yellow,
                [Resource.Green] = Color.Green,
                [Resource.GreenYellow] = Color.GreenYellow,
                [Resource.ForestGreen] = Color.ForestGreen,
                [Resource.Red] = Color.Red,
                [Resource.Blue] = Color.Blue,
            };
        }
        public Color Format(string raw)
        {
            return _map[raw];
        }
    }
}
