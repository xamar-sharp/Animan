using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Animan.Dependencies
{
    public interface IAssetProvider
    {
        byte[] Provide(string fileName);
    }
}
