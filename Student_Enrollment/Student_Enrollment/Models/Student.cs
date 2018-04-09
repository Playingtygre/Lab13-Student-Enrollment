using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Models
{
    public class Student
    {
        public int ID { get; set; } //Serves as student ID
        public string Name_First { get; set; }
        public string Name_Last { get; set; }
        public int Student_enrolled { get; set; }


        public List<Student> BuildStudents()
        {
            return new List<Student>
            {
                new Student(){Name_First="Ash", Name_Last="Ketchum", Student_enrolled = 1},
                new Student(){Name_First="Cardi", Name_Last="B", Student_enrolled = 1},
                new Student(){Name_First="Gary", Name_Last="Oak", Student_enrolled = 1},
            };
        }


    }
}
