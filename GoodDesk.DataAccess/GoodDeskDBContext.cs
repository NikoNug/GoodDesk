using GoodDesk.DataModel;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<TBLTTicket> TBLMTickets { get; set; } = null!;
        public virtual DbSet<TBLMPriority> TBLMPriorities{ get; set; } = null!;
        public virtual DbSet<TBLMStatus> TBLMStatuses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            // Table Priority
            modelBuilder.Entity<TBLMPriority>().HasData(
                new TBLMPriority
                {
                    ID = 1,
                    PriorityName = "Low",
                    Description = "Low priority",
                    Level = 1,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMPriority
                {
                    ID = 2,
                    PriorityName = "Medium",
                    Description = "Medium priority",
                    Level = 2,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMPriority
                {
                    ID = 3,
                    PriorityName = "High",
                    Description = "High priority",
                    Level = 3,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMPriority
                {
                    ID = 4,
                    PriorityName = "Critical",
                    Description = "Critical priority",
                    Level = 4,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                });

            // Table Status
            modelBuilder.Entity<TBLMStatus>().HasData(
                new TBLMStatus
                {
                    ID = 1,
                    StatusName = "Open",
                    Description = "Ticket has been created",
                    Level = 1,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMStatus
                {
                    ID = 2,
                    StatusName = "In Progress",
                    Description = "Ticket is being worked on",
                    Level = 2,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMStatus
                {
                    ID = 3,
                    StatusName = "Pending",
                    Description = "Ticket is waiting for additional information or action",
                    Level = 3,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMStatus
                {
                    ID = 4,
                    StatusName = "Resolved",
                    Description = "Issue has been resolved",
                    Level = 4,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                },
                new TBLMStatus
                {
                    ID = 5,
                    StatusName = "Closed",
                    Description = "Ticket has been closed",
                    Level = 5,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2026, 1, 1)
                }
            );

            modelBuilder.Entity<TBLTTicket>()
                .HasOne(t => t.Requester)
                .WithMany()
                .HasForeignKey(t => t.RequesterID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBLTTicket>()
                .HasOne(t => t.AssignedTo)
                .WithMany()
                .HasForeignKey(t => t.AssignedToID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBLTTicket>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBLTTicket>()
                .HasOne(t => t.Priority)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PriorityID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBLTTicket>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TBLMUser>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
