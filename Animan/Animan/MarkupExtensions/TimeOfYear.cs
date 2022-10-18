using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Animan.MarkupExtensions
{
    [ContentProperty("Name")]
    public sealed class TimeOfYear : IMarkupExtension
    {
        public string Name { get; set; }
        private static readonly IDictionary<int, string> _times;
        static TimeOfYear()
        {
            _times = new Dictionary<int, string>(5)
            {
                [11] = "Winter",
                [8] = "Autumn",
                [5] = "Summer",
                [2] = "Spring",
                [0] = "Winter"
            };
        }
        public string GetMonth()
        {
            var month = DateTime.Now.Month;
            string raw = "Winter";
            foreach (var m in _times)
            {
                if (month > m.Key)
                {
                    raw = m.Value;
                    break;
                }
            }
            return raw;
        }
        public object ProvideValue(IServiceProvider provider)
        {
            bool isnight = DateTime.Now.Hour > 19 || DateTime.Now.Hour < 5;
            var month = DateTime.Now.Month;
            string raw = "Winter";
            foreach(var m in _times)
            {
                if(month > m.Key)
                {
                    raw = m.Value;
                    break;
                }
            }
            return App.Current.Resources[$"{(isnight ? "Night" : "Day")}{raw}{Name}"] as Style;
        }
    }
}
