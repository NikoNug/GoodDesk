using GoodDesk.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Marshalling;

namespace GoodDesk.DataAccess
{
    public class GoodDeskDBContext : DbContext
    {
        public GoodDeskDBContext(
            DbContextOptions<GoodDeskDBContext> options) 
            : base(options) 
        { 
        }

        public virtual DbSet<TBLMCategory> TBLMCategories { get; set; } = null!;
        public virtual DbSet<TBLMRole> TBLMRoles { get; set; } = null!;
        public virtual DbSet<TBLMUser> TBLMUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBLMUser>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBLMRole>().HasData(
                new TBLMRole
                {
                    ID = 1,
                    RoleName = "Admin",
                    Description = "System Administrator",
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMRole
                {
                    ID = 2,
                    RoleName = "IT Support",
                    Description = "IT support staff",
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMRole
                {
                    ID = 3,
                    RoleName = "Requester",
                    Description = "User who creates support tickets",
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                }
            );

            modelBuilder.Entity<TBLMUser>().HasData(
                new TBLMUser
                {
                    ID = 1,
                    Username = "admin",
                    Email = "niko@gmail.com",
                    PasswordHash = "admin",
                    RoleID = 1,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                }
            );
        }
    }
}
