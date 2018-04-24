using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Student_Enrollment.Data
{
    public class School_Context : DbContext
    {
        //Lets set up the Database
        public School_Context(DbContextOptions<School_Context> options) : base(options)
        {

        }

        //Lets build the database
        public DbSet<Student_Enrollment.Models.Course> Course { get; set; }
        public DbSet<Student_Enrollment.Models.Student> Student { get; set; }

    }
}
