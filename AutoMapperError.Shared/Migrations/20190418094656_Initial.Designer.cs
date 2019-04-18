﻿// <auto-generated />
using System;
using AutoMapperError.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoMapperError.Shared.Migrations
{
    [DbContext(typeof(AutoMapperErrorContext))]
    [Migration("20190418094656_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoMapperError.Shared.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("LabId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LabId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("AutoMapperError.Shared.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AutoMapperError.Shared.Lab", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("AutoMapperError.Shared.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutoMapperError.Shared.Models.UserAssignment", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("AssignmentId");

                    b.Property<DateTime>("StartedAt");

                    b.HasKey("UserId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("UserAssignments");
                });

            modelBuilder.Entity("AutoMapperError.Shared.Assignment", b =>
                {
                    b.HasOne("AutoMapperError.Shared.Lab", "Lab")
                        .WithMany("Assignments")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoMapperError.Shared.Lab", b =>
                {
                    b.HasOne("AutoMapperError.Shared.Course", "Course")
                        .WithMany("Labs")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoMapperError.Shared.Models.UserAssignment", b =>
                {
                    b.HasOne("AutoMapperError.Shared.Assignment", "Assignment")
                        .WithMany("UserAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoMapperError.Shared.Models.User", "User")
                        .WithMany("UserAssignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}