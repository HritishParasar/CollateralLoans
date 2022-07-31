using AuthorizationService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Repo
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LoginModel> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<LoginModel>()
                .HasData(
                    new LoginModel
                    {
                        UserName="adminbak01",
                        Password="Firstpass@01"
                    },
                      new LoginModel
                      {
                          UserName = "adminbak02",
                          Password = "Secondpass@02"
                      }
                );
        }
    }
}
