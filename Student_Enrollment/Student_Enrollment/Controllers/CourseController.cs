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
        /// Query Method for finding a course
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

        /// <summary>
        /// Async method for searching for Enrollment
        /// </summary>
        /// <param name="course"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> Enrolled(string course, string searchString)
        {
            IQueryable<string> enrolledQuery = from e in _context.Student
                                               orderby e.Course
                                               select e.Course;

            var enrolled = from e in _context.Student
                           select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                enrolled = enrolled.Where(e => e.Course.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(course))
            {
                enrolled = enrolled.Where(e => e.Course == course);
            }

            var studentsVM = new CourseViewModel();
            studentsVM.student = new SelectList(await enrolledQuery.Distinct().ToListAsync());
            studentsVM.students = await enrolled.ToListAsync();

            return View(studentsVM);
        }


        /// <summary>
        /// async method for details about course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.SingleOrDefaultAsync(c => c.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// async method for creating course usinging a bind
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Level,Instructor")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        //Method for finding course by ID
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.SingleOrDefaultAsync(c => c.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        /// <summary>
        /// After finding by Id allowing for edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Level,Instructor")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");

            }

            return View(course);
        }

        //delete method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.SingleOrDefaultAsync(c => c.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var course = await _context.Course.SingleOrDefaultAsync(c => c.ID == id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(c => c.ID == id);
        }



    }//bottom
}
