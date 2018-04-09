using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Models;

namespace Student_Enrollment.Controllers
{
    public class CourseController : Controller
    {
        private readonly Student_EnrollmentContext _context;

        //brings in database and allows // for the student roster double this Make another needs another instance of the library
        public CourseController(Student_EnrollmentContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

            
    }
}
