using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence {
    public class AppContext : DbContext {
        // public AppContext() : base("name=AppContext") {
        //     this.Configuration.LazyLoadingEnabled = false;
        // }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public AppContext(DbContextOptions options) : base(options) {

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //     modelBuilder.Configurations.Add(new CourseConfiguration());
        // }
    }
}