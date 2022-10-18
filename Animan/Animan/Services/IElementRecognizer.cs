using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Animan.Services
{
    public interface IElementRecognizer
    {
        Task Recognize(AnimationContext ctx);
    }
}
