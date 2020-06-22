using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence {
    public class DataContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public DataContext(DbContextOptions options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Project>().HasData(
                new Project {
                    Id = 1,
                        Name = "value 101",
                        Version = 1.0,
                        Members = null
                },
                new Project {
                    Id = 2,
                        Name = "value 102",
                        Version = 1.0,
                        Members = null
                },
                new Project {
                    Id = 3,
                        Name = "value 103",
                        Version = 1.0,
                        Members = null
                });
        }
    }
}