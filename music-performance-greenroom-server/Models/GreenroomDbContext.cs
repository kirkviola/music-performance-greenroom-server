using Microsoft.EntityFrameworkCore;

namespace music_performance_greenroom_server.Models
{
    public class GreenroomDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<UserCourse> UserCourse { get; set; }
        public virtual DbSet<UserMaterial> UserMaterial { get; set; }
        public virtual DbSet<AssignmentMaterial> AssignmentMaterial { get; set; }
        public GreenroomDbContext(DbContextOptions<GreenroomDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");
                user.HasKey(user => user.UserId);
                user.Property(user => user.FirstName).HasMaxLength(60).IsRequired();
                user.Property(user => user.LastName).HasMaxLength(60).IsRequired();
                user.Property(user => user.FullName).HasMaxLength(125).IsRequired();
                user.Property(user => user.Email).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<Assignment>(assignment => {
                assignment.ToTable("Assignement");
                assignment.HasKey(assign => assign.AssignmentId);
                assignment.Property(assign => assign.AssignmentName).HasMaxLength(50).IsRequired();
                assignment.Property(assign => assign.AssignmentDescription).HasMaxLength(300).IsRequired(false).HasDefaultValue(null);
                assignment.Property(assign => assign.AssignmentMaxValue).HasColumnType("decimal(4,2)").HasDefaultValue(null);
                assignment.Property(assign => assign.AssignmentEarnedValue).HasColumnType("decmial(4,2)").HasDefaultValue(null);
                assignment.HasOne(assign => assign.Course)
                    .WithMany(course => course.Assignments)
                    .HasForeignKey(assign => assign.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Course>(course => 
            {
                course.ToTable("Course");
                course.HasKey(course => course.CourseId);
                course.Property(course => course.CourseName).HasMaxLength(50).IsRequired();
                course.Property(course => course.CourseDescription).HasMaxLength(300).IsRequired(false).HasDefaultValue(null);
            });

            modelBuilder.Entity<UserCourse>(UCourse =>
            {
                UCourse.ToTable("UserCourse");
                UCourse.HasKey(UCourse => UCourse.UserCourseId);
                UCourse.Property(UCourse => UCourse.IsOwner).IsRequired().HasDefaultValue(false);
                UCourse.HasOne(UCourse => UCourse.Course)
                    .WithMany(course => course.UserCourses)
                    .HasForeignKey(UCourse => UCourse.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                UCourse.HasOne(UCourse => UCourse.User)
                    .WithMany(user => user.UserCourses)
                    .HasForeignKey(UCourse => UCourse.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserMaterial>(material => 
            {
                material.ToTable("UserMaterial");
                material.HasKey(material => material.UserMaterialId);
                material.Property(material => material.UserMaterialName).HasMaxLength(50).IsRequired();
                material.Property(material => material.UserMaterialDescription).HasMaxLength(300).IsRequired(false).HasDefaultValue(null);
                material.HasOne(material => material.User)
                    .WithMany(user => user.UserMaterials)
                    .HasForeignKey(material => material.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AssignmentMaterial>(material =>
            {
                material.ToTable("AssignmentMaterial");
                material.HasKey(material => material.AssignmentMaterialId);
                material.Property(material => material.AssignmentMaterialName).HasMaxLength(50).IsRequired();
                material.Property(material => material.AssignmentMaterialDescription).HasMaxLength(300).IsRequired(false).HasDefaultValue(null);
                material.HasOne(material => material.Assignment)
                    .WithMany(user => user.AssignmentMaterials)
                    .HasForeignKey(material => material.AssignmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
