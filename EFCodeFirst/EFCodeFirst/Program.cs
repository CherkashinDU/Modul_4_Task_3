using System;
using System.IO;
using System.Linq;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCodeFirst
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            using (var db = new ApplicationContext(options))
            {
                var office = db.Offices.Single(o => o.Location == "Ukraine");
                var title = db.Titles.Single(t => t.Name == "PM");
                var employee = db.Employees.Add(new Employee { FirstName = "Frodo", LastName = "Baggins", HiredDate = DateTime.UtcNow, DateOfBirth = new DateTime(1980, 10, 3), OfficeId = office.Id, TitleId = title.Id });
                db.SaveChanges();

                var project = db.Projects.First(p => p.StartedDate >= DateTime.UtcNow.AddYears(-3));
                db.EmployeeProjects.Add(new EmployeeProject { Rate = 65, StartedDate = project.StartedDate.AddMonths(3), EmployeeId = employee.Entity.Id, ProjectId = project.Id });
                db.SaveChanges();
            }
        }
    }
}
