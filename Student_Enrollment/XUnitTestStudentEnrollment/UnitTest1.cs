using System;
using Xunit;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using Student_Enrollment.Controllers;
using Microsoft.EntityFrameworkCore;


namespace XUnitTestStudentEnrollment
{
    public class UnitTest1
    {
        [Fact]
        public void CourseTestNull()
        {
            Course course1 = new Course() { ID = 1, Name = "testCourse"};

            Assert.NotNull(course1);
        }

        [Fact]
        public void CanGetId()
        {
            Course course = new Course()
            {
                ID = 1
            };

            Assert.Equal(1, course.ID);
        }

        [Fact]
        public void CanGetName()
        {
            Course course = new Course()
            {
                Name = "Math"
            };

            Assert.Equal("Math",course.Name);
        }

        [Fact]
        public void CanGetLevel()
        {
            Course course = new Course()
            {
                Level = 100
            };

            Assert.Equal(100, course.Level);
        }

        [Fact]
        public void CanGetInstructor()
        {
            Course course = new Course()
            {
                Instructor = "Lin"
            };

            Assert.Equal("Lin", course.Instructor);
        }

    }
}
