using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Models
{
    public class Course
    {

        public int ID { get; set; } //This is alway primary key
        public String CourseName {get;set;}
        public String Description { get; set; }
        public Student Student { get; set; } // matches with student because we will connect them.


        //Need to create student/Course controller CRUD is in each.
    }
}
