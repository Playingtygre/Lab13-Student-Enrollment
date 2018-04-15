using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Student
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; } 
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string Class { get; set; }
    }
}
