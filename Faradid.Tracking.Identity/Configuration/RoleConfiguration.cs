using Faradid.Tracking.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Identity.Configuration
{
    public class RoleConfiguration:IEntityTypeConfiguration<CustomRole>
    {
        public void Configure(EntityTypeBuilder<CustomRole> builder)
        {
            builder.HasData(
                                new CustomRole
                                {
                                    Id = 1,
                                    Name = "Administrator",
                                    NormalizedName = "ADMINISTRATOR"
                                },
                new CustomRole
                {
                    Id = 2,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }

                );
        }
    }
}
