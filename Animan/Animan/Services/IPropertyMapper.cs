using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Animan.Services
{
    public interface IPropertyMapper<T> where T : Xamarin.Forms.View
    {
        Task Map(AnimationContext ctx, T target, string current);
    }
}
