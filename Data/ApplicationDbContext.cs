using AssignmentApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace AssignmentApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StudentEntity> Student { get; set; }

     
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseEnrollment> Enrollments { get; set; }
       

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CourseEnrollment>()
        //         .HasKey(e => new { e.StudentID, e.CourseID });

        //    modelBuilder.Entity<CourseEnrollment>()
        //        .HasOne(e => e.Student)
        //        .WithMany(s => s.Enrollments)
        //        .HasForeignKey(e => e.StudentID);

        //    modelBuilder.Entity<CourseEnrollment>()
        //        .HasOne(e => e.Course)
        //        .WithMany(c => c.Enrollments)
        //        .HasForeignKey(e => e.CourseID);

        //    base.OnModelCreating(modelBuilder);
        //}
    }

}