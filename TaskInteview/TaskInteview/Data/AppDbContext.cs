using Microsoft.EntityFrameworkCore;
using TaskInteview.Configuration;
using TaskInteview.Model;

namespace TaskInteview.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = 1,
                  Name = "Farid",
                  Surname = "Mammadov",
                  BirthDate = "10.10.1999",
                  DepartmentId = 1                

              },
              new Employee
              {
                  Id = 2,
                  Name = "Elgun",
                  Surname = "Guluzade",
                  BirthDate = "02.02.1992",
                  DepartmentId = 1

              },
              new Employee
              {
                  Id = 3,
                  Name = "Tural",
                  Surname = "Cavadov",
                  BirthDate = "03.03.1993",
                  DepartmentId = 1

              },
              new Employee
              {
                  Id = 4,
                  Name = "Ulvi",
                  Surname = "Macidov",
                  BirthDate = "04.04.1995",
                  DepartmentId = 2

              },
              new Employee
              {
                  Id = 5,
                  Name = "Tural",
                  Surname = "Mammadov",
                  BirthDate = "04.04.1995",
                  DepartmentId = 1

              },
              new Employee
              {
                  Id = 6,
                  Name = "Tural",
                  Surname = "Ehmedov",
                  BirthDate = "04.04.1995",
                  DepartmentId = 1

              });
            modelBuilder.Entity<Department>().HasData(
             new Department
             {
                 Id = 1,
                 Name = "Programing",

             },
             new Department
             {
                 Id = 2,
                 Name = "Biznes",

             });
        }
    }
}
