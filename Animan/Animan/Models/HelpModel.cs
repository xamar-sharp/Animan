using System;
using System.Collections.Generic;
using System.Text;
using Animan.Constants;
namespace Animan.Models
{
    public sealed class HelpModel
    {
        //OR RETURN TYPE
        public string Command { get; set; }
        //WITH PROPERTY : ACCESSED RETURN TYPES
        //OR ALLOWED RETYPE VALUES
        public string[] Properties { get; set; }
        //Description
        public string Description { get; set; }
        //Return type or command
        public HelpType Type { get; set; }
    }
}
