using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeDepatment> EmployeeDepatment { get; set; }
        public DbSet<AssignedTaskStatus> TaskStatus { get; set; }
        public DbSet<AssignedTask> Task { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedEmplyeeData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedEmplyeeData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                new Role { ID = 1, Name = "Admin"},
                new Role { ID = 2, Name = "Manager"},
                new Role { ID = 3, Name = "Employee"}
                );

            modelBuilder.Entity<User>().HasData(
                new User { ID = 1,
                    Name = "Admin",
                    Birthday = new DateTime(1980 , 1 , 1),
                    Email = "Admin@gmail.com" ,
                    Password = "123456",
                    Username = "Admin",
                    PhoneNumber = "01200000000",
                    RoleID = 1
                });

            modelBuilder.Entity<AssignedTaskStatus>().HasData(
                new AssignedTaskStatus { ID = 1, Name = "New" },
                new AssignedTaskStatus { ID = 2, Name = "Complated" }
                );
        }
    }
}
