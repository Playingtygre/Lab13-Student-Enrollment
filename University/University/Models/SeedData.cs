using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using University.Data;

namespace University.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<StudentDbContext>>()))
            {
                if (context.Students.Any())
                {
                    return;
                }

                context.Students.AddRange(
                    new Student
                    {
                        FirstName= "Ash",
                        LastName="Ketchum",
                        Class = "superfly",
                        DOB = DateTime.Parse("1989-1-11"),
                    }

                    new Student
                    {
                        FirstName = "Ashly",
                        LastName = "booy",
                        Class = "funny mate",
                        DOB = DateTime.Parse("1989-1-11"),
                    }





                    );

                context.SaveChanges();

            }

            

        }
   

    }
}
