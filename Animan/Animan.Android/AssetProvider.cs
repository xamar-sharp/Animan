using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content.Res;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System.IO;
using Android.Views;
using Android.Widget;
using Animan.Dependencies;
namespace Animan.Droid
{
    public sealed class AssetProvider:IAssetProvider
    {
        internal static AssetManager AssetManager;
        public byte[] Provide(string fileName)
        {
            using(var stream = AssetManager.Open(fileName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }
            }
        }
    }
}