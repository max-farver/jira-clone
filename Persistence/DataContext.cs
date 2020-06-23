using Domain.Projects;
using Domain.Tasks;
using Domain.Users;
using Domain.Sprints;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<User>
    {

        // public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // give User PK of string
            base.OnModelCreating(builder);
            builder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "value 101",
                    Version = 1.0,
                    Members = null
                },
                new Project
                {
                    Id = 2,
                    Name = "value 102",
                    Version = 1.0,
                    Members = null
                },
                new Project
                {
                    Id = 3,
                    Name = "value 103",
                    Version = 1.0,
                    Members = null
                });
        }
    }
}