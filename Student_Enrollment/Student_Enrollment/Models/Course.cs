using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Student_Enrollment.Models
{
    public class Course
    {
        //Course.Property. Primary Key
        public int ID { get; set; }

        //Course.Property.Name
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        //Course.Property.Level
        [Required]
        public int Level { get; set; }

        // Course.Property. Instructor Name
        public string Instructor { get; set; }

    }
}
