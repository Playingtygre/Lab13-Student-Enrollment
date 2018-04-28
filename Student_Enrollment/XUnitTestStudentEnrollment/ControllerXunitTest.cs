using System;
using Xunit;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using Student_Enrollment.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace XUnitTestStudentEnrollment
{
    public class ControllerXtest
    {
        private School_Context _context;


        [Fact]
        public async void CanCreate()
        {
            DbContextOptionsBuilder<School_Context> builder = new DbContextOptionsBuilder<School_Context>();
            builder.UseInMemoryDatabase();
            DbContextOptions<School_Context> options = builder.Options;
            _context = new School_Context(options);


            Student student = new Student() {FirstName="jimmy" };
            _context.Student.Add(student);
            _context.SaveChanges();

            Student foundEntity = _context.Student.FirstOrDefault(x => x.FirstName == student.FirstName);

            Assert.NotNull(foundEntity);
            
        }

        [Fact]
        public void CanGetIndex()
        {
            HomeController controller = new HomeController();

            Assert.IsType<ViewResult>(controller.Index());
        }


        [Fact]
        public async void CanDelete()
        {
            DbContextOptionsBuilder<School_Context> builder = new DbContextOptionsBuilder<School_Context>();
            builder.UseInMemoryDatabase();
            DbContextOptions<School_Context> options = builder.Options;
            _context = new School_Context(options);


            Student student = new Student() { FirstName = "jimmy" };
            _context.Student.Add(student);
            _context.SaveChanges();

            Student foundEntity = _context.Student.FirstOrDefault(x => x.FirstName == student.FirstName);

            Assert.NotNull(foundEntity);

        }



    }




}
