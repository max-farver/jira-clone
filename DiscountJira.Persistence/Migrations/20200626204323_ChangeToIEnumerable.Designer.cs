﻿// <auto-generated />
using System;
using DiscountJira.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscountJira.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200626204323_ChangeToIEnumerable")]
    partial class ChangeToIEnumerable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("DiscountJira.Core.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaskItemId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskItemId");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("DiscountJira.Core.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<double>("Version")
                        .HasColumnType("REAL");

                    b.Property<bool>("isArchived")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "value 101",
                            Version = 1.0,
                            isArchived = false,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            Name = "value 102",
                            Version = 1.0,
                            isArchived = false,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            Name = "value 103",
                            Version = 1.0,
                            isArchived = false,
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("DiscountJira.Core.Models.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointsPlanned")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("DiscountJira.Core.Models.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EstimatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isArchived")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DiscountJira.Core.Models.AppUser", b =>
                {
                    b.HasOne("DiscountJira.Core.Models.Project", null)
                        .WithMany("Members")
                        .HasForeignKey("ProjectId");

                    b.HasOne("DiscountJira.Core.Models.TaskItem", null)
                        .WithMany("AssignedMembers")
                        .HasForeignKey("TaskItemId");
                });

            modelBuilder.Entity("DiscountJira.Core.Models.Sprint", b =>
                {
                    b.HasOne("DiscountJira.Core.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("DiscountJira.Core.Models.TaskItem", b =>
                {
                    b.HasOne("DiscountJira.Core.Models.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
