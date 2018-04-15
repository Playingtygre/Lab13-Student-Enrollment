using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeRandom.Models
{
    public class CourseViewModel
    {
        public List<Course> courses;
        public List<Student> students;
        public SelectList name;
        public SelectList student;
        public string CourseName { get; set; }

    }
}
