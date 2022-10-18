using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class LayoutOptionsMapper:IValueFormatter<LayoutOptions>
    {
        private static readonly IDictionary<string, LayoutOptions> _map;
        static LayoutOptionsMapper()
        {
            _map = new Dictionary<string, LayoutOptions>(8)
            {
                [Resource.StartAndExpand]=LayoutOptions.StartAndExpand,
                [Resource.Start] = LayoutOptions.Start,
                [Resource.CenterAndExpand] = LayoutOptions.CenterAndExpand,
                [Resource.Center] = LayoutOptions.Center,
                [Resource.EndAndExpand] = LayoutOptions.EndAndExpand,
                [Resource.End] = LayoutOptions.End,
                [Resource.FillAndExpand] = LayoutOptions.FillAndExpand,
                [Resource.Fill] = LayoutOptions.Fill
            };
        }
        public LayoutOptions Format(string raw)
        {
            return _map[raw];
        }
    }
}
