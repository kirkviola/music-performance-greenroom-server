using Microsoft.EntityFrameworkCore;
using music_performance_greenroom_server.Models;

namespace music_performance_greenroom_server.Models
{
    public class GreenroomDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<UserCourse> UserCourse { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public GreenroomDbContext(DbContextOptions<GreenroomDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");
                user.HasKey(user => user.Id);
                user.Property(user => user.FirstName).HasMaxLength(60).IsRequired();
                user.Property(user => user.LastName).HasMaxLength(60).IsRequired();
                user.Property(user => user.Password).HasMaxLength(100).IsRequired();
                user.Property(user => user.Email).HasMaxLength(250).IsRequired();
                user.HasIndex(user => user.Email).IsUnique();
            });

            modelBuilder.Entity<Assignment>(assignment => {
                // Timestamp column configured in annotation
                assignment.ToTable("Assignement");
                assignment.HasKey(assign => assign.Id);
                assignment.Property(assign => assign.Name).HasMaxLength(50).IsRequired();
                assignment.Property(assign => assign.Description).HasMaxLength(300).IsRequired(false).HasDefaultValue(null);
                assignment.Property(assign => assign.MaxValue).HasColumnType("decimal(4,2)").HasDefaultValue(null);
                assignment.Property(assign => assign.EarnedValue).HasColumnType("decimal(4,2)").HasDefaultValue(null);
                assignment.HasOne(assign => assign.Course)
                    .WithMany(course => course.Assignments)
                    .HasForeignKey(assign => assign.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Course>(course => 
            {
                course.ToTable("Course");
                course.HasKey(course => course.Id);
                course.Property(course => course.Title).HasMaxLength(50).IsRequired();
                course.Property(course => course.Description).HasMaxLength(300).IsRequired(false).HasDefaultValue(null);
            });

            modelBuilder.Entity<UserCourse>(UCourse =>
            {
                UCourse.ToTable("UserCourse");
                UCourse.HasKey(UCourse => UCourse.Id);
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

            modelBuilder.Entity<Material>(material =>
            {
                material.ToTable("Material");
                material.HasKey(material => material.Id);
                material.Property(material => material.Title).HasMaxLength(50).IsRequired();
                material.Property(material => material.Description).HasMaxLength(500).IsRequired(false).HasDefaultValue(null);
                material.Property(material => material.Attachment).HasColumnType("varbinary(max)");
                material.Property(material => material.Url).HasMaxLength(500).IsRequired(false).HasDefaultValue(null);
                material.HasOne(material => material.User)
                    .WithMany(user => user.Materials)
                    .HasForeignKey(material => material.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                material.HasOne(material => material.Assignment)
                    .WithMany(assignment => assignment.Materials)
                    .HasForeignKey(material => material.AssignmentId)
                    .OnDelete(DeleteBehavior.SetNull);
                material.Property(material => material.AssignmentId).IsRequired(false).HasDefaultValue(null);
            });

            modelBuilder.Entity<Group>(group => 
            {
                group.ToTable("Group");
                group.HasKey(group => group.Id);
                group.Property(group => group.Name).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<UserGroup>(group => 
            {
                group.ToTable("UserGroup");
                group.HasKey(group => group.Id);
                group.HasOne(group => group.User)
                    .WithMany(user => user.UserGroups)
                    .HasForeignKey(group =>  group.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                group.HasOne(group => group.Group)
                    .WithMany(group => group.UserGroups)
                    .HasForeignKey(group => group.GroupId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserPermission>(permission => 
            {
                permission.ToTable("UserPermission");
                permission.HasKey(permission => permission.Id);
                permission.Property(permission => permission.Permission).HasMaxLength(30).IsRequired();
                permission.HasOne(permission => permission.User)
                    .WithMany(user => user.UserPermissions)
                    .HasForeignKey(permission => permission.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public DbSet<music_performance_greenroom_server.Models.UserGroup> UserGroup { get; set; }
    }
}
