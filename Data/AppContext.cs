using LanguageClassesApiApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageClassesApiApp.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
