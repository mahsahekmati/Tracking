using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Identity.Models
{    /// <summary>
     /// this class overwrite for change id of type string to type int
     /// </summary>
    public class CustomRole: IdentityRole<int>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
