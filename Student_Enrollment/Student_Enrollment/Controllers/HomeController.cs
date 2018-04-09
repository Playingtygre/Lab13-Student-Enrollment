﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Enrollment.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Methods inside controllers are actions
            return View();
        }

        [HttpPost]
        public IActionResult Index(string StudentsListNames) // this is collected from index.cshtml
        {
            return View();
        }

    }
}
