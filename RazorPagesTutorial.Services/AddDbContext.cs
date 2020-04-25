using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesTutorial.Services
{
   public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
