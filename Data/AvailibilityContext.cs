using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Availibility.Models;

namespace Availibility.Data
{
    public class AvailibilityContext : DbContext
    {
        public AvailibilityContext (DbContextOptions<AvailibilityContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Availibility.Models.Appointment> Appointment { get; set; }
    }
}
