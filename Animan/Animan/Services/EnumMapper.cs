using System;
using System.Collections.Generic;
using System.Text;

namespace Animan.Services
{
    public sealed class EnumMapper<T> : IValueFormatter<T> where T : struct
    {
        public T Format(string raw)
        {
            var res = Enum.TryParse<T>(raw, out T value);
            return res ? value : (T)Enum.Parse(typeof(T), Enum.GetNames(typeof(T))[0]);
        }
    }
}
