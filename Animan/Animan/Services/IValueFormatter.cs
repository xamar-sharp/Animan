using System;
using System.Collections.Generic;
using System.Text;

namespace Animan.Services
{
    public interface IValueFormatter<T>
    {
        T Format(string raw);
    }
}
