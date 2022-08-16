using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
                                    <ApplicationUser, ApplicationRole, string,
                                    IdentityUserClaim<string>, ApplicationUserRole,
                                    IdentityUserLogin<string>,
                                    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<Categories> Category { get; set; }
        public virtual DbSet<Transactions> Transaction { get; set; }
        public virtual DbSet<SubCategories> SubCategories { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Screens> Screens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            base.OnModelCreating(builder);

            builder.UseCollation("utf8_general_ci");
            builder.HasDefaultSchema("dbs5610869");

            builder.Entity<ApplicationUserRole>(userRole =>
            {

                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}