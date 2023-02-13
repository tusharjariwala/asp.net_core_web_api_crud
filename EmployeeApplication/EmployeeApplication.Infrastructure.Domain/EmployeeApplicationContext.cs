using EmployeeApplication.Infrastructure.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Domain
{
    public class EmployeeApplicationContext:DbContext
    {
        public EmployeeApplicationContext(DbContextOptions<EmployeeApplicationContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new List<Company>
            {
                new Company(1,"Abc"),
                new Company(2,"Xyz"),

            });
        }
    }
}
