﻿// <auto-generated />
using EMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EMS.Data.Migrations
{
    [DbContext(typeof(EMSContext))]
    [Migration("20190123080204_addTaskModule")]
    partial class addTaskModule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMS.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EMS.Data.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactType");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EMS.Data.Models.CricketTeam", b =>
                {
                    b.Property<string>("CriTeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CriTeamCaptionContact");

                    b.Property<string>("CriTeamCaptionEmail");

                    b.Property<string>("CriTeamCaptionName");

                    b.Property<string>("CriTeamName");

                    b.Property<string>("CriTeamNonVegitarion");

                    b.Property<string>("CriTeamParticipations");

                    b.Property<string>("CriTeamVegitarion");

                    b.HasKey("CriTeamID");

                    b.ToTable("CricketTeams");
                });

            modelBuilder.Entity("EMS.Data.Models.Department", b =>
                {
                    b.Property<string>("DprtId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DprtName");

                    b.HasKey("DprtId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EMS.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentDprtId");

                    b.Property<string>("EmpAddress1");

                    b.Property<string>("EmpAddress2");

                    b.Property<string>("EmpContact");

                    b.Property<string>("EmpEmail");

                    b.Property<string>("EmpGender");

                    b.Property<string>("EmpId");

                    b.Property<string>("EmpName");

                    b.Property<string>("EmpPassword");

                    b.Property<string>("EmpProfilePicture");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("PositionId");

                    b.Property<string>("PositionPId");

                    b.Property<int>("ProjectPrId");

                    b.Property<string>("RegisterCode");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentDprtId");

                    b.HasIndex("PositionId");

                    b.HasIndex("ProjectPrId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EMS.Data.Models.EmployeeTask", b =>
                {
                    b.Property<int>("EId");

                    b.Property<int>("TaskId");

                    b.HasKey("EId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("EMS.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EventClosingDate");

                    b.Property<string>("EventDescription");

                    b.Property<DateTime>("EventEndDate");

                    b.Property<string>("EventId");

                    b.Property<string>("EventName");

                    b.Property<DateTime>("EventStartDate");

                    b.Property<int>("EventTypeId");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("EMS.Data.Models.EventImages", b =>
                {
                    b.Property<string>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Caption");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("EventId");

                    b.Property<bool>("IsActive");

                    b.HasKey("ImageId");

                    b.ToTable("EventImages");
                });

            modelBuilder.Entity("EMS.Data.Models.Eventtype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventTypeDescription");

                    b.Property<string>("EventTypeId");

                    b.Property<string>("EventTypeName");

                    b.HasKey("Id");

                    b.ToTable("Eventtypes");
                });

            modelBuilder.Entity("EMS.Data.Models.FrontPage", b =>
                {
                    b.Property<string>("CriEventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CriEventContent1");

                    b.Property<string>("CriEventContent2");

                    b.Property<DateTime>("CriEventDate");

                    b.Property<DateTime>("CriEventDeadLine");

                    b.Property<string>("CriEventMainTopic");

                    b.Property<string>("CriEventPlace");

                    b.Property<string>("CriEventSubTopic");

                    b.Property<DateTime>("CriEventTime");

                    b.HasKey("CriEventId");

                    b.ToTable("FrontPages");
                });

            modelBuilder.Entity("EMS.Data.Models.OneDayTripRegistrant", b =>
                {
                    b.Property<string>("PKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeId");

                    b.Property<string>("EventId");

                    b.Property<string>("NumberOfFamilyMembers");

                    b.Property<string>("TransportationMode");

                    b.HasKey("PKey");

                    b.ToTable("OneDayTripRegistrants");
                });

            modelBuilder.Entity("EMS.Data.Models.Position", b =>
                {
                    b.Property<string>("PositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionDis");

                    b.Property<string>("PositionName");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EMS.Data.Models.Project", b =>
                {
                    b.Property<int>("PrId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<string>("ProjectDescription");

                    b.Property<string>("ProjectId");

                    b.Property<string>("ProjectName");

                    b.HasKey("PrId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EMS.Data.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("ActualCost");

                    b.Property<DateTime>("AddDate");

                    b.Property<float>("BudgetedCost");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("EventName");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Status");

                    b.Property<string>("TaskName");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("EMS.Data.Models.TaskInformation", b =>
                {
                    b.Property<int>("InfoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("File");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("Task");

                    b.HasKey("InfoID");

                    b.HasIndex("Task");

                    b.ToTable("TaskInformations");
                });

            modelBuilder.Entity("EMS.Data.Models.Test", b =>
                {
                    b.Property<string>("EmpName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("EmpName");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("EMS.Data.Models.TwoDayTripRegistrants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Accomadation");

                    b.Property<string>("EmployeeId");

                    b.Property<string>("EventId");

                    b.Property<string>("MealTypeNonVegi");

                    b.Property<string>("MealTypeVegi");

                    b.Property<string>("NumberOfFamilyMembers");

                    b.Property<string>("PKey");

                    b.Property<string>("TransportationMode");

                    b.HasKey("Id");

                    b.ToTable("TwoDayTripRegistrant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EMS.Data.Models.Employee", b =>
                {
                    b.HasOne("EMS.Data.Models.Department")
                        .WithMany("Emp")
                        .HasForeignKey("DepartmentDprtId");

                    b.HasOne("EMS.Data.Models.Position")
                        .WithMany("Employee")
                        .HasForeignKey("PositionId");

                    b.HasOne("EMS.Data.Models.Project")
                        .WithMany("employees")
                        .HasForeignKey("ProjectPrId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EMS.Data.Models.EmployeeTask", b =>
                {
                    b.HasOne("EMS.Data.Models.Employee", "Employee")
                        .WithMany("EmployeeTasks")
                        .HasForeignKey("EId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EMS.Data.Models.Task", "Task")
                        .WithMany("EmployeeTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EMS.Data.Models.Event", b =>
                {
                    b.HasOne("EMS.Data.Models.Eventtype")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EMS.Data.Models.TaskInformation", b =>
                {
                    b.HasOne("EMS.Data.Models.Task", "TaskId")
                        .WithMany("TaskInformation")
                        .HasForeignKey("Task");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EMS.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EMS.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EMS.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EMS.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}