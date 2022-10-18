using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using System.Linq;
using Animan.Models;
using Newtonsoft.Json;
namespace Animan.Services
{
    public sealed class HelpProvider
    {
        private readonly HelpModel[] _values;
        public HelpProvider(HelpModel[] values)
        {
            _values = values;
        }
        public IList<HelpModel> Provide()
        {
            return JsonConvert.DeserializeObject<HelpModel[]>(Preferences.Get("Helps", "[]")).ToList();
        }
        public void Init()
        {
            Preferences.Set("Helps", JsonConvert.SerializeObject(_values));
        }
    }
}
