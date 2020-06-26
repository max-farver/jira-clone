using DiscountJira.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountJira.Persistence
{
    public class DataContext : DbContext
    {
        public virtual DbSet<TaskItem> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "value 101",
                    Version = 1.0
                },
                new Project
                {
                    Id = 2,
                    Name = "value 102",
                    Version = 1.0
                },
                new Project
                {
                    Id = 3,
                    Name = "value 103",
                    Version = 1.0
                });
        }
    }
}