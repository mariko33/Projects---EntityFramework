using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BookShopSystem.Models;

namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookShopSystem.Data.BookShopSystemContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShopSystem.Data.BookShopSystemContext context)
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


            Random random=new Random();
          //  SeedAuthors(context);
            var authors = context.Authors.ToList();
           // SeedBooks(context,random,authors);
            SeedCategories(context,random);

        }


        private static void SeedCategories(BookShopSystemContext context, Random random)
        {
            using (var reader=new StreamReader("c:\\users\\toshiba\\documents\\visual studio 2015\\Projects\\BookShopSystemProject\\BookShopSystem.Models\\categories.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line!=null)
                {
                    var data = line.Split(new[] {' '});
                    var name = data[0];
                    var books = context.Books.ToArray();
                    HashSet<Book>booksToAdd=new HashSet<Book>()
                    {
                        books[random.Next(books.Length)],
                        books[random.Next(books.Length)],
                        books[random.Next(books.Length)]
                    };
                    context.Categories.AddOrUpdate(cat=>cat.Name,
                        new Category()
                        {
                            Name = name,
                            Books = booksToAdd
                        });

                    line = reader.ReadLine();
                }
            }
        }


        private static void SeedBooks(BookShopSystemContext context, Random random, List<Author>authors )
        {
            using (var reader=new StreamReader("c:\\users\\toshiba\\documents\\visual studio 2015\\Projects\\BookShopSystemProject\\BookShopSystem.Models\\books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line!=null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditionType)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = Decimal.Parse(data[3],CultureInfo.InvariantCulture);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.AddOrUpdate(book=>book.Title,
                        new Book()
                        {
                            Author = author,
                            EditionType = edition,
                            ReleaseDate = releaseDate,
                            Copies = copies,
                            Price = price,
                            AgeRestriction = ageRestriction,
                            Title = title
                        });

                    line = reader.ReadLine();
                }
            }
            context.SaveChanges();
        }

        private static void SeedAuthors(BookShopSystemContext context)
        {
            using (var reader=new StreamReader("c:\\users\\toshiba\\documents\\visual studio 2015\\Projects\\BookShopSystemProject\\BookShopSystem.Models\\authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line!=null)
                {
                    var data = line.Split(new[] {' '});
                    var firstName = data[0];
                    var lastName = data[1];

                    context.Authors.AddOrUpdate(author=>author.FirstName,
                        new Author()
                        {
                            FirstName = firstName,
                            LastName = lastName
                        });
                    line = reader.ReadLine();
                }
            }
            context.SaveChanges();
        }



    }
}
