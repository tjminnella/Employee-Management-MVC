//Install-Package Microsoft.EntityFrameworkCore.Tools
//Update-Package Microsoft.EntityFrameworkCore.Tools
//Get-Help about_EntityFrameworkCore
//add-migration
//update-migration

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Example of using Fluent API instaed of attributes
            //to limit the length of a category name to 15
            /*modelBuilder.Entity<Action>()
                .Property(action => action.Name)
                .IsRequired() //Not Null
                .HasMaxLength(100);*/

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string path = System.IO.Path.Combine(
             //   System.Environment.CurrentDirectory, "Northwind.db");
            
            //optionsBuilder.UseSqlServer($"Filename={path}");
        }*/
    }
}
