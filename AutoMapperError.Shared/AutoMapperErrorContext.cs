using AutoMapperError.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperError.Shared
{
    public class AutoMapperErrorContext : DbContext
    {
        public AutoMapperErrorContext() : base(new DbContextOptionsBuilder<AutoMapperErrorContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AutoMapperErrorContext-1555580227;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAssignment>().HasKey(x => new {x.UserId, x.AssignmentId});
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
    }
}
