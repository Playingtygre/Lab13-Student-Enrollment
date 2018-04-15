using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CollegeRandom.Models
{
    public class Course
    {
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        public string Instructor { get; set; }
    }
}
