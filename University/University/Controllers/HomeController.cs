using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext _context;

        public HomeController(StudentDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            _context.Add(student);
            _context.SaveChanges();

            return RedirectToAction("ViewAllStudents", "Enrollment");
        }






    }
}
