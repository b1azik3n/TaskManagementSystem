using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;



namespace DataAccessLayer.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectAssign> ProjectMembers { get; set; }

        public  DbSet<DailyLog> DailyLogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskAssign> TaskProjects { get; set; }
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DailyLog>()
        //        .HasOne(l => l.User)
        //        .WithMany(u => u.DailyLogs)
        //        .HasForeignKey(l => l.UserId);
        //}
    }

}
