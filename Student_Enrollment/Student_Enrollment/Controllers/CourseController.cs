using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Student_Enrollment.Controllers
{
    public class CourseController : Controller
    {
        //Read only Context
        private readonly Data.School_Context _context;

        // setting the Controller to _context
        public CourseController(School_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="course"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> Index(string course, string searchString)
        {
            IQueryable<string> courseQuery = from c in _context.Course
                                             orderby c.Name
                                             select c.Name;

            var courses = from c in _context.Course
                          select c;
        
        if(!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.Name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(course))
            {
                courses = courses.Where(c => c.Name == course);
            }

            var courseNamesVM = new CourseViewModel();
            courseNamesVM.name = new SelectList(await courseQuery.Distinct().ToListAsync());
            courseNamesVM.courses = await courses.ToListAsync();


            return View(courseNamesVM);
        }



    }//bottom
}
