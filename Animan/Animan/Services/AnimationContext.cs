using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class AnimationContext
    {
        internal readonly NavigationPage MainPage;
        internal readonly StackLayout Canvas;
        public AnimationContext(NavigationPage mainPage, StackLayout canvas)
        {
            MainPage = mainPage;
            Canvas = canvas;
        }
        internal string LastElement { get; set; }
        internal string LastProperty { get; set; }
        internal string LastValue { get; set; }
        internal IDictionary<string,string> LastProperties { get; set; }
    }
}
