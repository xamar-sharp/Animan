using System;
using System.Collections.Generic;
using System.Text;

namespace Animan.Services
{
    public sealed class BooleanMapper : IValueFormatter<bool>
    {
        public bool Format(string raw)
        {
            return Convert.ToBoolean(raw);
        }
    }
}
