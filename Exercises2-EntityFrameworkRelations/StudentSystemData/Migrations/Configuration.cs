using System.Collections.Generic;
using StudentSystemModels;

namespace StudentSystemData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemData.StudentSystem>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentSystemData.StudentSystem";
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(StudentSystem context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }

            //    );
            //

            context.Homeworks.AddOrUpdate(
                h=>h.Content,
                new Homework
                {
                    Content = "C#Advanced",
                    ContentType = ContentType.Zip,
                    Student = context.Students.SingleOrDefault(s=>s.Id==1),
                   // Course = context.Courses.SingleOrDefault(c=>c.Id==1),
                    SubmissionDate = new DateTime(2016, 11, 15)
                }
                );
            context.Courses.AddOrUpdate(
                c=>c.Name,
                new Course
                {
                    Name = "C#",
                    Description = "Something",
                    Price = 150.00m,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2017,2,3),
                    Students = new HashSet<Student>
                    {
                        new Student
                        {
                            Name = "Pesho",
                            PhoneNumber = "0878995522",
                            Birthday = new DateTime(1993,1,1),
                            RegistrationDate = DateTime.Now

                        },
                        new Student
                        {
                            Name = "Misho",
                            PhoneNumber = "0878995522",
                            Birthday = new DateTime(1993,1,1),
                            RegistrationDate = DateTime.Now

                        },
                        new Student
                        {
                            Name = "Pepi",
                            PhoneNumber = "0878995522",
                            Birthday = new DateTime(1993,1,1),
                            RegistrationDate = DateTime.Now

                        }


                    },
                    Homeworks = new HashSet<Homework>
                    {
                        new Homework
                        {
                            Content = "nanana",
                            ContentType = ContentType.Application,
                            Student = new Student
                            {
                                Name = "Krisi",
                                PhoneNumber = "0898745566",
                                Birthday = new DateTime(1991,02,02),
                                RegistrationDate = DateTime.Now
                            },
                            SubmissionDate = new DateTime(2016,11,15)
                        },
                        new Homework
                        {
                            Content = "C#-introduction",
                            ContentType = ContentType.Application,
                            Student = new Student
                            {
                                Name = "Mili",
                                PhoneNumber = "0898745566",
                                Birthday = new DateTime(1991,02,02),
                                RegistrationDate = DateTime.Now
                            },
                            SubmissionDate = new DateTime(2016,11,15)
                        }
                        
                    },
                    Resources = new HashSet<Resource>
                    {
                        new Resource
                        {
                            Name = "BookC#",
                            TypeOfResource = TypeOfResource.Document,
                            Url = "//mdkdmmmdel"
                        },
                        new Resource
                        {
                            Name = "Blog",
                            TypeOfResource = TypeOfResource.Other,
                            Url = "//llmfof.lodej"
                        }
                    }


                }


                );



            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course
                {
                    Name = "C#Advanced",
                    Description = "Something",
                    Price = 150.00m,
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2017, 2, 3),
                    Students = new HashSet<Student>
                    {
                        new Student
                        {
                            Name = "Niko",
                            PhoneNumber = "0878995522",
                            Birthday = new DateTime(1993,1,1),
                            RegistrationDate = DateTime.Now

                        },
                        new Student
                        {
                            Name = "Vanio",
                            PhoneNumber = "0878995522",
                            Birthday = new DateTime(1993,1,1),
                            RegistrationDate = DateTime.Now

                        },
                        new Student
                        {
                            Name = "Valentin",
                            PhoneNumber = "0878995522",
                            Birthday = new DateTime(1993,1,1),
                            RegistrationDate = DateTime.Now

                        }


                    },
                    Homeworks = new HashSet<Homework>
                    {
                        new Homework
                        {
                            Content = "Course Introduction",
                            ContentType = ContentType.Application,
                            Student = context.Students.SingleOrDefault(s=>s.Id==3),
                            SubmissionDate = new DateTime(2016,11,15)
                        },
                        new Homework
                        {
                            Content = "C#-Advanced",
                            ContentType = ContentType.Application,
                            Student = context.Students.SingleOrDefault(s=>s.Id==4),
                            SubmissionDate = new DateTime(2016,11,15)
                        }

                    },
                    Resources = new HashSet<Resource>
                    {
                        new Resource
                        {
                            Name = "NakovsBook",
                            TypeOfResource = TypeOfResource.Document,
                            Url = "//mdkdmmmdel"
                        },
                        new Resource
                        {
                            Name = "BlogBlog",
                            TypeOfResource = TypeOfResource.Other,
                            Url = "//llmfof.lodej"
                        }
                    }


                }


                );

            context.SaveChanges();

        }
    }
}
