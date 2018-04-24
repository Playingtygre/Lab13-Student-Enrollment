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
    public class StudentController : Controller
    {
        //Read only Context
        private readonly Data.School_Context _context;

        // setting the Controller to _context
        public StudentController(School_Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string student, string searchString)
        {
            //LINQ query Everything in Students
            IQueryable<string> studentQuery = from s in _context.Student
                                               orderby s.FirstName
                                               select s.FirstName;

            // all students in Context from students
            var students = from s in _context.Student
                           select s;

            //searchstring.student
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstName.Contains(searchString));
            }
            //searchstring.student equals
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstName == student);
            }

            var studentNamesVM = new StudentViewModel(); 
            //calls student query from above 
            studentNamesVM.firstName = new SelectList(await studentQuery.Distinct().ToListAsync());
            //complies student names to list in async
            studentNamesVM.students = await students.ToListAsync();

            return View(studentNamesVM);
        }

        // Async lets find a  student id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // LINQ statment for every c in student looks for a id in student
            var student = await _context.Student.SingleOrDefaultAsync(c => c.ID == id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        /// <summary>
        /// Create method
        /// </summary>
        /// <returns></returns>
       
        //Create I action result
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create method for student IF there is a vaild student in that ID
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>

        //PosT method using _context save changes 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Course")] Student student)
        {
            //boolean true or false 
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        /// <summary>
        /// Async method for looking at and editing if a student is avaiable  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Student.SingleOrDefaultAsync(c => c.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        /// <summary>
        /// Async method for finding student by ID, If they exsits then allow to add to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Course")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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

            return View(student);
        }///////////////////////////////////////////
        /// <summary>
        /// Async Delete method for finding by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        
        /// <summary>
        /// async Method for delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(s => s.ID == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// If student ID is found pulls students by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool StudentExists(int id)
        {
            return _context.Student.Any(c => c.ID == id);
        }



    }//Bottom of the Student Controller
}
