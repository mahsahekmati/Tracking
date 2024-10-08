﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Faradid.Tracking.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1
                },
                  new IdentityUserRole<int>
                  {
                      UserId = 2,
                      RoleId = 2
                  }
                );
        }
    }
}
