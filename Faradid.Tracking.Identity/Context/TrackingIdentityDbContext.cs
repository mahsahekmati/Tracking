using Faradid.Tracking.Identity.Configuration;
using Faradid.Tracking.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Identity.Context
{
    public class TrackingIdentityDbContext: IdentityDbContext<ApplicationUser, IdentityRole<int>, 
    int>
    {
        public TrackingIdentityDbContext(DbContextOptions<TrackingIdentityDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }
}
