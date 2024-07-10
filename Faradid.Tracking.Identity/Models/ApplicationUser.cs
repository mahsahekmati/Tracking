using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Identity.Models
{
    public class ApplicationUser:IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
