using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Student_Enrollment.Models
{
    public class StudentViewModel
    {
        //Student . Properties
        public List<Student> students;
        public SelectList firstName;
        public string StudentName { get; set; }
    }
}
