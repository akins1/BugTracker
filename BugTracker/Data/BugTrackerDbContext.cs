using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data
{
    public class BugTrackerDbContext : DbContext
    {
        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options) : base(options)
        {

        }

        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProjectComment> ProjectComment { get; set; }
        public DbSet<ProjectHistory> ProjectHistory { get; set; }
        public DbSet<TicketHistory> TicketHistory { get; set; }
        public DbSet<TicketComment> TicketComment { get; set; }
        public DbSet<ProjectManagedByJunction> ProjectManagedByJunction { get; set; }
        public DbSet<ProjectDevelopersJunction> ProjectDevelopersJunction { get; set; }
        public DbSet<TicketAssignedToJunction> TicketAssignedToJunction { get; set; }

        // ProjectComment
        // ProjectHistory
        // TicketHistory
        // TicketComment
        // ProjectManagedByJunction
        // ProjectDevelopersJunction
        // TicketAssignedToJunction

    }
}
