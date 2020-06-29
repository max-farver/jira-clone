using System.Collections.Generic;
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
        }
    }
}