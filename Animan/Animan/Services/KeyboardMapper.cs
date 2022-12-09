using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class KeyboardMapper : IValueFormatter<Keyboard>
    {
        private static readonly IDictionary<string, Keyboard> _map;
        static KeyboardMapper()
        {
            _map = new Dictionary<string, Keyboard>(8)
            {
                [Resource.Plain] = Keyboard.Plain,
                [Resource.Telephone] = Keyboard.Telephone,
                [Resource.Chat] = Keyboard.Chat,
                [Resource.Numeric] = Keyboard.Numeric,
                [Resource.Email] = Keyboard.Email,
                [Resource.Text] = Keyboard.Text,
                [Resource.Url] = Keyboard.Url
            };
        }
        public Keyboard Format(string raw)
        {
            return _map[raw];
        }
    }
}
