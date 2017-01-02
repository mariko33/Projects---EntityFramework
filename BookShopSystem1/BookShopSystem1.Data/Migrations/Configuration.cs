using System.Collections.Generic;
using BookShopSystem1.Models;

namespace BookShopSystem1.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem1.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShopSystem1.Data.BookShopContext";
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(BookShopContext context)
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
            //context.Books.Add(new Book
            //    {
            //        EditionType = EditionType.Normal,
            //        ReleaseDate = new DateTime(20/01/1998),
            //        Copies = 27274,
            //        Price = 15.31m,
            //        AgeRestriction = AgeRestriction.Teen,
            //        Title = "Absalom"
            //    });

            //context.Books.Add(new Book
            //{
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(5/5/1997),
            //    Copies = 6713,
            //    Price = 45.78m,
            //    Title = "A che punto Ã¨ la notte"
            //});

            //context.Books.Add(new Book
            //{
                
            //    ReleaseDate = new DateTime(14/09/1998),
            //    Copies = 16159,
            //    Price = 35.56m,
            //    Title = "After Many a Summer Dies the Swan"
            //});
            //context.Books.Add(new Book
            //{
               
            //    ReleaseDate = new DateTime(13/03/1999),
            //    Copies = 29025,
            //    Price = 23.71m,
            //    Title = "Ah"
            //});

            //context.Books.Add(new Book
            //{
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(12/3/1993),
            //    Copies = 9998,
            //    Price = 5.26m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "Wilderness!"
            //});

            //List<Book>booksList=new List<Book>()
            //{
            //   new Book()
            //   { EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(22/10/2014),
            //    Copies = 18832,
            //    Price = 5.69m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "Alien CornÂ (play)" },

            //   new Book()
            //   { 
            //    ReleaseDate = new DateTime(18/02/2003),
            //    Copies = 28741,
            //    Price = 34.56m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "The Alien CornÂ (short story)" },

            //   new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(11/10/1991),
            //    Copies = 20471,
            //    Price = 7.18m,
            //    AgeRestriction = AgeRestriction.Minor,
            //    Title = "All Passion Spent"
            //   },

            //    new Book()
            //   {
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(29/03/1996),
            //    Copies = 9457,
            //    Price = 45.6m,
            //    Title = "All the King's Men"
            //    },

            //    new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(30/11/2000),
            //    Copies = 17327,
            //    Price = 14.99m,
            //    Title = "Alone on a Wide"
            //    },

            //    new Book()
            //   {
               
            //    ReleaseDate = new DateTime(23/04/1998),
            //    Copies = 3226,
            //    Price = 24.37m,
            //    AgeRestriction = AgeRestriction.Minor,
            //    Title = "Wide Sea"
            //    },

            //    new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(8/3/1996),
            //    Copies = 6171,
            //    Price = 34.64m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "An Acceptable Time"
            //   },

            //    new Book()
            //   {
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(7/9/2005),
            //    Copies = 10049,
            //    Price = 38.51m,
            //    AgeRestriction = AgeRestriction.Minor,
            //    Title = "Antic Hay"
            //   },

            //    new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(10/10/1996),
            //    Copies = 21765,
            //    Price = 3.3m,
            //    Title = "An Evil Cradling"
            //   },

            //     new Book()
            //   {
                
            //    ReleaseDate = new DateTime(24/01/2001),
            //    Copies = 2408,
            //    Price = 24.4m,             
            //    Title = "Arms and the Man"
            //   },

            //     new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(25/04/1992),
            //    Copies = 2997,
            //    Price = 25.81m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "As I Lay Dying"
            //   },


            //     new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(25/09/2006),
            //    Copies = 29543,
            //    Price = 20.21m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "A Time to Kill"
            //   },

            //     new Book()
            //   {
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(28/10/2011),
            //    Copies = 4893,
            //    Price = 18.01m,
            //    Title = "Behold the Man"
            //   },

            //     new Book()
            //   {
            //    EditionType = EditionType.Normal,
            //    ReleaseDate = new DateTime(23/08/2012),
            //    Copies = 8159,
            //    Price = 23.83m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "Beneath the Bleeding"
            //   },

            //     new Book()
            //   {
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(17/05/2006),
            //    Copies = 24103,
            //    Price = 45.45m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "Beyond the Mexique Bay"
            //   },


            //       new Book()
            //   {
                
            //    ReleaseDate = new DateTime(25/03/2001),
            //    Copies = 22304,
            //    Price = 16.68m,
            //    AgeRestriction = AgeRestriction.Minor,
            //    Title = "Blithe Spirit"
            //   },


            //          new Book()
            //   {

            //    ReleaseDate = new DateTime(4/5/2007),
            //    Copies = 28137,
            //    Price = 28.97m,
            //    AgeRestriction = AgeRestriction.Teen,
            //    Title = "Blood's a Rover"
            //   },

            //       new Book()
            //   {
            //    EditionType = EditionType.Prormo,
            //    ReleaseDate = new DateTime(3/3/1999),
            //    Copies = 20946,
            //    Price = 9.76m,
            //    Title = "Blue Remembered Earth"
            //   }

            //};

            //foreach (var book in booksList)
            //{
            //    context.Books.Add(book);
            //}

            //context.SaveChanges();


        }
    }
}
