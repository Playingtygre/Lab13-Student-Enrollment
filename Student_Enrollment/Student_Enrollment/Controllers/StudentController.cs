using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string StudentsListNames)
        {
            return RedirectToAction("Results", new {StudentsListNames});
        }

        public IActionResult Result(string StudentsListNames)
        {
            return View();
        }

       
    }
}
