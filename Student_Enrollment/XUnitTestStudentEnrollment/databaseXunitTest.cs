using System;
using Xunit;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using Student_Enrollment.Controllers;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestStudentEnrollment
{
    public class databaseXunitTest
    {
        School_Context _context;


        /*
        public DatabaseXunitTest()
        {
            DbContextOptions<School_Context> options = new DbContextOptionsBuilder<School_Context>()
              .UseInMemoryDatabase(Guid.NewGuid().ToString())
              .Options;
            _context = new School_Context(options);

        }

        [Fact]
        public void GetSentiment()
        {
            Image testSentiment = new Image()
            {
                Sentiment = 0.94f
            };

            Assert.Equal(0.94f, testSentiment.Sentiment);
        }
        */

    }
}
