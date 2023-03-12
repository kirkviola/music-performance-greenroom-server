﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using music_performance_greenroom_server.Models;

#nullable disable

namespace music_performance_greenroom_server.Migrations
{
    [DbContext(typeof(GreenroomDbContext))]
    partial class GreenroomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("music_performance_greenroom_server.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<string>("AssignmentDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal?>("AssignmentEarnedValue")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal?>("AssignmentMaxValue")
                        .HasColumnType("decimal(4,2)");

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ChangeTime")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignement", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.AssignmentMaterial", b =>
                {
                    b.Property<int>("AssignmentMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentMaterialId"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<byte[]>("AssignmentMaterialAttachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("AssignmentMaterialDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AssignmentMaterialName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AssignmentMaterialId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentMaterial", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserCourseId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("GroupId");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.UserCourse", b =>
                {
                    b.Property<int>("UserCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCourseId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourse", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.UserGroup", b =>
                {
                    b.Property<int>("UserGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserGroupId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserGroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroup", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.UserMaterial", b =>
                {
                    b.Property<int>("UserMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserMaterialId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("UserMaterialAttachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserMaterialDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("UserMaterialName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserMaterialId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMaterial", (string)null);
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.Assignment", b =>
                {
                    b.HasOne("music_performance_greenroom_server.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.AssignmentMaterial", b =>
                {
                    b.HasOne("music_performance_greenroom_server.Models.Assignment", "Assignment")
                        .WithMany("AssignmentMaterials")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.UserCourse", b =>
                {
                    b.HasOne("music_performance_greenroom_server.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("music_performance_greenroom_server.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.UserGroup", b =>
                {
                    b.HasOne("music_performance_greenroom_server.Models.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("music_performance_greenroom_server.Models.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.UserMaterial", b =>
                {
                    b.HasOne("music_performance_greenroom_server.Models.User", "User")
                        .WithMany("UserMaterials")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.Assignment", b =>
                {
                    b.Navigation("AssignmentMaterials");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.Group", b =>
                {
                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("music_performance_greenroom_server.Models.User", b =>
                {
                    b.Navigation("UserCourses");

                    b.Navigation("UserGroups");

                    b.Navigation("UserMaterials");
                });
#pragma warning restore 612, 618
        }
    }
}
