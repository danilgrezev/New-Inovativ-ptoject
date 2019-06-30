﻿// <auto-generated />
using Backend5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Backend5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190630124337_Mig09")]
    partial class Mig09
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend5.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("GeoId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Rating");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("GeoId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Backend5.Models.ApplicationUserTaskType", b =>
                {
                    b.Property<int>("ApplicationUserId");

                    b.Property<int>("TaskTypeId");

                    b.Property<string>("ApplicationUserId1");

                    b.HasKey("ApplicationUserId", "TaskTypeId");

                    b.HasIndex("ApplicationUserId1");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("ApplicationUserTaskTypes");
                });

            modelBuilder.Entity("Backend5.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("ApplicationUserId1");

                    b.Property<string>("CVV")
                        .IsRequired();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId1");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Backend5.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("RecipientId");

                    b.Property<string>("SenderId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend5.Models.Geo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("District");

                    b.HasKey("Id");

                    b.ToTable("Geos");
                });

            modelBuilder.Entity("Backend5.Models.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("Backend5.Models.MyTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ApplyingTime");

                    b.Property<string>("ClientId");

                    b.Property<string>("EmployeeId");

                    b.Property<DateTime>("ExecutionTime");

                    b.Property<int>("GeoId");

                    b.Property<string>("Header");

                    b.Property<int>("InsuranceId");

                    b.Property<int>("Priority");

                    b.Property<string>("Status");

                    b.Property<int>("TaskTypeId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("GeoId");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Backend5.Models.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("Backend5.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("IdentityRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRoles");
                });

            modelBuilder.Entity("Backend5.Models.ApplicationUser", b =>
                {
                    b.HasOne("Backend5.Models.Geo", "Geo")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("GeoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.UserType", "UserType")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.ApplicationUserTaskType", b =>
                {
                    b.HasOne("Backend5.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("TaskTypes")
                        .HasForeignKey("ApplicationUserId1");

                    b.HasOne("Backend5.Models.TaskType", "TaskType")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.Card", b =>
                {
                    b.HasOne("Backend5.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Cards")
                        .HasForeignKey("ApplicationUserId1");
                });

            modelBuilder.Entity("Backend5.Models.Comment", b =>
                {
                    b.HasOne("Backend5.Models.ApplicationUser", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("Backend5.Models.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("Backend5.Models.MyTask", b =>
                {
                    b.HasOne("Backend5.Models.ApplicationUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Backend5.Models.ApplicationUser", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Backend5.Models.Geo", "Geo")
                        .WithMany("MyTasks")
                        .HasForeignKey("GeoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
