using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Student_Enrollment.Models
{
    public class Student_EnrollmentContext : DbContext
    {
       
        // THIS IS THE MAIN DATA CONTROLLER & a constructor
        public Student_EnrollmentContext (DbContextOptions<Student_EnrollmentContext> options)
            : base(options)
        {
        }


        public DbSet<Student_Enrollment.Models.Course> Course { get; set; } // makes the list of courses

        public DbSet<Student> Students { get; set;} // makes another table of the list of studnts 

    }
}
