using System;
using System.Collections.Generic;
using System.Text;

namespace Animan.Services
{
    public sealed class DoubleMapper:IValueFormatter<double>
    {
        public double Format(string raw)
        {
            return Convert.ToDouble(raw);
        }
    }
}
