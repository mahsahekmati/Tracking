using Faradid.Tracking.Domain.Entities.Common;
using Faradid.Tracking.Domain.Entities.Users;
using Faradid.Tracking.Identity.Configuration;
using Faradid.Tracking.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Faradid.Tracking.Persistence.Context
{
    public class TrackingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>,
    int>
    {

        public TrackingDbContext(DbContextOptions<TrackingDbContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersBarcode> UsersBarcodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackingDbContext).Assembly);
        }



        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.EditDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.EditDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
