﻿// <auto-generated />
using System;
using Labb2Linq.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2Linq.Migrations
{
    [DbContext(typeof(LinqDbContext))]
    [Migration("20240418110033_tablefix")]
    partial class tablefix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb2Linq.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseGrade")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkTeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.HasIndex("FkTeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Labb2Linq.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FkCourseId")
                        .HasColumnType("int");

                    b.Property<int>("FkStudentId")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkStudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Labb2Linq.Models.SchoolClass", b =>
                {
                    b.Property<int>("SchoolClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolClassId"));

                    b.Property<int?>("FkTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("SchoolClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolClassId");

                    b.HasIndex("FkTeacherId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("Labb2Linq.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("FkSchoolClassId")
                        .HasColumnType("int");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("FkSchoolClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Labb2Linq.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Labb2Linq.Models.Course", b =>
                {
                    b.HasOne("Labb2Linq.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("FkTeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Labb2Linq.Models.Enrollment", b =>
                {
                    b.HasOne("Labb2Linq.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2Linq.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("FkStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Labb2Linq.Models.SchoolClass", b =>
                {
                    b.HasOne("Labb2Linq.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("FkTeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Labb2Linq.Models.Student", b =>
                {
                    b.HasOne("Labb2Linq.Models.SchoolClass", "SchoolClass")
                        .WithMany()
                        .HasForeignKey("FkSchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");
                });

            modelBuilder.Entity("Labb2Linq.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
