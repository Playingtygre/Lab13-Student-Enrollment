using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Student_Enrollment.Models
{
    public class Student
    {
        //student.property.PrimaryKEy
        public int ID { get; set; }

        //student.property.FirstNAme
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        //student.property.LastName
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }

        //student.property.Course Name
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Course { get; set; }

    }
}
