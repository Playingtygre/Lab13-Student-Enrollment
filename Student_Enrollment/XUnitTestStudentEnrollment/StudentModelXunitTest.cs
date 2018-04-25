using System;
using Xunit;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using Student_Enrollment.Controllers;
using Microsoft.EntityFrameworkCore;



namespace XUnitTestStudentEnrollment
{
    public class StudentModelXunitTest
    {
        [Fact]
        public void CanGetStudentId()
        {
            Student student = new Student()
            {
                ID = 1
            };

            Assert.Equal(1, student.ID);
        }


        [Fact]
        public void CanGetStudentFirstNAme()
        {
            Student student = new Student()
            {
                FirstName = "Tiger"
            };

            Assert.Equal("Tiger", student.FirstName);
        }

        [Fact]
        public void CanGetStudentLastName()
        {
            Student student = new Student()
            {
                LastName = "Trump"
            };

            Assert.Equal("Trump", student.LastName);
        }

    }
}
