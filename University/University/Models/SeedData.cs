using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Data;
using Microsoft.Extensions.DependencyInjection;

namespace University.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                if (context.Course.Any())
                {
                    return;
                }

                context.Course.AddRange
                    (
                    new Course
                    {
                        Name = "MATH",
                        Instructor = "Tim",
                        Level = 500,
                    }

                  );
                context.SaveChanges();






            }

        }


    }
}
