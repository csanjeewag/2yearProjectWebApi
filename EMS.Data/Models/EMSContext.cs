using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Models
{
    public class EMSContext : IdentityDbContext<ApplicationUser>
    {
        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RUHANGI\SQLEXPRESS;Initial Catalog=DBApi5;Integrated Security=True");
        //}

        public EMSContext(DbContextOptions<EMSContext> options) : base(options)
        {

        }
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<EventImages> EventImages { get; set; }
        public DbSet<FrontPage> FrontPages { get; set; }
        public DbSet<CricketTeam> CricketTeams { get; set; }
        public DbSet<Project>  Projects { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Event> EventsDetails { get; set; }
        public DbSet<OneDayTripRegistrant> OneDayTripRegistrants { get; set; }
        public DbSet<TwoDayTripRegistrants> TwoDayTripRegistrant { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Eventtype> Eventtypes { get; set; }

        public DbSet<TaskInformation> TaskInformations { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }


        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Employee>()
                 .HasOne(p => p.Project)
                 .WithMany(b => b.employees)
                 .HasForeignKey(p => p.ProjectId)
                 .HasConstraintName("ForeignKey_Project_Employee");
         }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeTask>()
                .HasKey(et => new { et.Id, et.TaskId });
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTasks)
                .HasForeignKey(et => et.Id);
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Task)
                .WithMany(t => t.EmployeeTasks)
                .HasForeignKey(et => et.TaskId);
        }
    }
}
 