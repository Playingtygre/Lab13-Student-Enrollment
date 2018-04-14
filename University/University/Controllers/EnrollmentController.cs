using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;
using Microsoft.EntityFrameworkCore;


namespace University.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly StudentDbContext _context;

        public EnrollmentController(StudentDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IActionResult ViewAllStudents(string sortType)
        {

            List<Student> students = _context.Students.ToList();

            if (!String.IsNullOrEmpty(sortType))
            {
                switch (sortType)
                {
                    case "FN":
                        students = students.OrderBy(s => s.FirstName).ToList();
                        break;
                    case "LS":
                        students = students.OrderBy(s => s.LastName).ToList();
                        break;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult FilteredStudentsByName(String studentName)
        {
            //forming a new list of students using a constructor
            List<Student> students = new List<Student>();
            if (!(String.IsNullOrEmpty(studentName)))
            {
                students = _context.Students.Where(s => s.FirstName.ToLower() == studentName.ToLower()).ToList();

                return View(students);
            }
            return View(students);
        }

        [HttpPost]
        public IActionResult FilterStudentsByName(string studentName)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("ViewAllStudents");

            return RedirectToAction("FilterStudentsByName", new {studentName});
        }

        [HttpGet]
        public IActionResult FilteredByClass(string className)
        {
            List<Student> students = new List<Student>();
            if (!(string.IsNullOrEmpty(className)))
            {
                students = _context.Students.Where(s => s.Class.ToLower() == className.ToLower()).ToList();

                return View(students);
            }
            return View(students);

        }

        [HttpPost]
        public IActionResult FilterByClass(string className)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("ViewAllStudents");
            return RedirectToAction("FilteredByClass", new { className });
        
        }

    }
}

