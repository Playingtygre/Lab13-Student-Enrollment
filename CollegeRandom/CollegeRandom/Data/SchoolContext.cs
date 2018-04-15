using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CollegeRandom.Data
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<CollegeRandom.Models.Course> Course { get; set; }
        public DbSet<CollegeRandom.Models.Student> Student { get; set; }

    }
}
