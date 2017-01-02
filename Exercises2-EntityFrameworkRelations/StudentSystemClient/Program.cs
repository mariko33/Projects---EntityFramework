using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystemData;
using StudentSystemModels;

namespace StudentSystemClient
{
    class Program
    {
        static void Main()
        {
            StudentSystem context =new StudentSystem();
            //context.Database.Initialize(true);
            //AllStudentWithThereSubmission(context);


            //ListAllCourses(context);

            //AllCoursesWith5MoreResourses(context);

            //AllCoursesInAGivenDate(context,new DateTime(2016, 11, 20));

            AllStudentWithCoursesInfo(context);

            //context.SaveChanges();

        }


        private static void AllStudentWithCoursesInfo(StudentSystem context)
        {
            var students = context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name);

            
            foreach (var student in students)
            {
                if (student.Courses.Count != 0)

                {
                    Console.WriteLine($"{student.Name} {student.Courses.Count} {student.Courses.Sum(c => c.Price)}" +
                                      $" {student.Courses.Average(c => c.Price)}");


                }
                
            }
        }

        private static void AllCoursesInAGivenDate(StudentSystem context, DateTime activeDate)
        {
            var courses = context.Courses.Where(c => c.StartDate < activeDate || c.EndDate < activeDate)
                .OrderBy(c => c.Students.Count)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = SqlFunctions.DateDiff("day", c.StartDate, c.EndDate),
                    StudentsCount=c.Students.Count

                });
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.StartDate} {course.EndDate}--Duration{course.Duration}--{course.StudentsCount}");
            }
        }

        private static void AllStudentWithThereSubmission(StudentSystem context)
        {
            var students = context.Students;
            foreach (var student in students)
            {
                Console.WriteLine(student.Name); 
                foreach (var hom in student.Homeworks)
                {
                    Console.WriteLine($"{hom.Content} {hom.ContentType}");
                }    
            }          

        }

        private static void ListAllCourses(StudentSystem context)
        {
            var courses = context.Courses
                .OrderBy(course => course.StartDate)
                .ThenByDescending(course => course.EndDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.Description}");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"{resource.Name} {resource.TypeOfResource} {resource.Url}");
                }
            }
        }

        private static void AllCoursesWith5MoreResourses(StudentSystem context)
        {
            var courses = context.Courses.Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenBy(c => c.StartDate);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.Resources.Count}");
            }
        }

    }
}
