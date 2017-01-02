using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BookShopSystem.Data;
using BookShopSystem.Models;
using EntityFramework.Extensions;

namespace BookShopSystem.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            BookShopSystemContext context =new BookShopSystemContext();
            context.Database.Initialize(true);

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            //1.Get all books after the year 2000. Print only their titles
            //var booksAfter2000 = context.Books
            //    .Where(b => b.ReleaseDate.Year > 2000)
            //    .Select(b => new
            //    {
            //        Title=b.Title
            //    });
            //foreach (var book in booksAfter2000)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //2. Get all authors with at least one book with release date before 1990. Print their first name and last name

            //var authors = context.Authors
            //    .Where(a=>a.Books.Count(b=>b.ReleaseDate.Year<1990)>0)
            //    .Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName

            //    });
            //foreach (var author in authors)
            //{
            //    Console.WriteLine($"{author.FirstName} {author.LastName}");

            //}

            //3.Get all authors, ordered by the number of their books(descnding). Print their first name, last name and book count
            //var autnors = context.Authors
            //    .OrderByDescending(a => a.Books.Count)
            //    .Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName,
            //        bookCount = a.Books.Count
            //    });
            //foreach (var author in autnors)
            //{
            //    Console.WriteLine($"{author.FirstName} {author.LastName} {author.bookCount}");

            //}
            //.4 Get all books from author Gorge Powell
            //var books = context.Books
            //    .Where(b => b.Author.FirstName.Equals("George") && b.Author.LastName.Equals("Powell"))
            //    .OrderByDescending(b => b.ReleaseDate)
            //    .ThenBy(b => b.Title)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        b.ReleaseDate,
            //        b.Copies
            //    });
            //foreach (var book in books)
            //{
            //    Console.WriteLine($"{book.Title} {book.ReleaseDate} {book.Copies}");
            //}

            //5.Get the most recent books from each category


            //var mostRecentbooks = context.Categories
            //    .OrderByDescending(c => c.Books.Count)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.Books.Count,
            //        books=c.Books.OrderBy(b => b.ReleaseDate).ThenBy(b => b.Title).Take(3)
            //    });

            //foreach (var mostRecentBook in mostRecentbooks)
            //{
            //    Console.WriteLine($"--{mostRecentBook.Name}: {mostRecentBook.Count}");
            //    foreach (var book in mostRecentBook.books)
            //    {
            //        Console.WriteLine($"{book.Title} {book.ReleaseDate.Year}");
            //    }

            //}


            //var books = context.Books.Take(3).ToList();
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //context.SaveChanges();


            //var booksFromQuery = context.Books.Take(3)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        relatedBooks = b.RelatedBooks
            //    });

            //foreach (var book in booksFromQuery)
            //{
            //    Console.WriteLine($"--{book.Title}");
            //    foreach (var relatedBook in book.relatedBooks)
            //    {
            //        Console.WriteLine($"{relatedBook.Title}");
            //    }
            //}


            //Exercise-Advance Querying--

            //Task 2
            //BooksByAgeRestriction(context);

            //Task 3
            //GoldenBooks(context);

            //Task 4
            //BooksByPrice(context);

            //Task 5
            //NotReleasedBooks(context);

            //Task 6
            //BookTitlesByCategory(context);

            //Task 7
           // BooksReleasedBeforeDate(context);

            //Task 8
            //AuthorsSearch(context);

            //Task 9
            //BooksSearch(context);

            //Task 10
            //BookTitlesSearch(context);

            //Task 11
            //CountBooks(context);

            //Task 12
            //TotalBookCopies(context);

            //Task 13
            //FindProfit(context);

            //Task 14
           // MostRecentBooks(context);

            //Task 15
           // IncreaseBookCopies(context);

            //Таск 16
            //RemoveBooks(context);

        }


        public static void RemoveBooks(BookShopSystemContext context)
        {
            Console.WriteLine("Write a number");
            int number = int.Parse(Console.ReadLine());
            var count = context.Books.Count(b => b.Copies < number);
            Console.WriteLine($"{count} books were deleted");
            context.Books.Delete(b => b.Copies < number);
            context.SaveChanges();


        }

        public static void IncreaseBookCopies(BookShopSystemContext context)
        {
            Console.WriteLine("Write a date in format dd MMM yyyy");
            string firstInput = Console.ReadLine();
            DateTime dateGiven=DateTime.ParseExact(firstInput,"dd MMM yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Write a number");
            int numberIncrease = int.Parse(Console.ReadLine());
            var count = context.Books.Count(b => b.ReleaseDate > dateGiven);
            Console.WriteLine(count);
            var books = context.Books.Where(b => b.ReleaseDate > dateGiven);
            //Using EF Extended
            context.Books.Update(books, book=>new Book() {Copies = book.Copies+numberIncrease});
            context.SaveChanges();

        }
           

        public static void MostRecentBooks(BookShopSystemContext context)
        {
            foreach (var count in context.Categories.Select(c=>c.Books.Count))
            {
                Console.WriteLine(count);
            }

            var categories = context.Categories
                .Where(c => c.Books.Count > 35)
                .OrderByDescending(c => c.Books.Count)
                .Select(c => new
                {
                    name = c.Name,
                    booksCount=c.Books.Count(),
                    books =
                    c.Books.OrderByDescending(b => b.Copies)
                        .Take(3)
                        .OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title)
                });
            foreach (var cat in categories)
            {
                Console.WriteLine($"--{cat.name}: {cat.booksCount}");
                foreach (var book in cat.books)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Year})");
                }
            }
        }

        public static void FindProfit(BookShopSystemContext context)
        {
            var profitByCategories = context.Categories
                .GroupBy(c => new
                {
                    categoryName = c.Name,
                    profit = c.Books.Sum(book => book.Price*book.Copies)
                })
                .OrderByDescending(p => p.Key.profit)
                .ThenBy(p => p.Key.categoryName);
            foreach (var prof in profitByCategories)
            {
                Console.WriteLine($"{prof.Key.categoryName} - ${prof.Key.profit}");
            }


        }

        public static void TotalBookCopies(BookShopSystemContext context)
        {
            var authors = context.Authors.OrderByDescending(a => a.Books.Sum(b => b.Copies));
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Books.Sum(b=>b.Copies)}");
            }
        }

        public static void CountBooks(BookShopSystemContext context)
        {
            Console.Write("Write a number:  ");
            int number = int.Parse(Console.ReadLine());
            var books = context.Books.Count(b => (b.Title.Length) > number);
                
            Console.WriteLine($"There are {books} books with longer title then {number} symbols");

        }

        public static void BookTitlesSearch(BookShopSystemContext context)
        {
            Console.Write("Write any string:  ");
            string givenString = Console.ReadLine().ToLower();
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(givenString))
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                });

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }


        }

        public static void BooksSearch(BookShopSystemContext context)
        {
           Console.WriteLine("Write any string:   ");
            string givenString = Console.ReadLine().ToLower();
            var booksTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(givenString))
                .Select(b => b.Title);

            foreach (string title in booksTitles)
            {
               Console.WriteLine(title);   
            }

        }
        public static void AuthorsSearch(BookShopSystemContext context)
        {
            Console.Write("Write end string:  ");
            string endString = Console.ReadLine();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(endString))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                });
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
                
            }
        }
        public static void BooksReleasedBeforeDate(BookShopSystemContext context)
        {
            Console.Write("Write a date in format dd-MM-yyyy   ");
            string givenDate = Console.ReadLine();
           DateTime dateRelease = DateTime.ParseExact(givenDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var booksBeforeGivenDate = context.Books
                .Where(b => b.ReleaseDate < dateRelease)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                });
            foreach (var book in booksBeforeGivenDate)
            {
              Console.WriteLine($"{book.Title} - {book.EditionType} - {book.Price}");   
            }
        }

        public static void BookTitlesByCategory(BookShopSystemContext context)
        {
            Console.WriteLine("Write categories:");
            var categoryNames = Console.ReadLine().Split(' ').ToList();
            //categories = Regex.Replace(categories, @"\s+", " ");
            //string[] categoriesList = categories.Split(' ');
            var titles = context.Books
                .Where(b => b.Categories.Count(category => categoryNames.Contains(category.Name)) != 0)
                .Select(b => b.Title);

            foreach (string bookTitle in titles)
            {
                Console.WriteLine(bookTitle);
            }



        }
        public static void NotReleasedBooks(BookShopSystemContext context)
        {
            Console.Write("Write a year:  ");
            string year = Console.ReadLine();
            var notReleasedBooks = context.Books
                .Where(b => b.ReleaseDate.Year.ToString() != year)
                .Select(b => new
                {
                   b.Title

                });
            foreach (var book in notReleasedBooks)
            {
                Console.WriteLine(book.Title);
            }

        }
        public static void BooksByPrice(BookShopSystemContext context)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            var booksByPrice = context.Books
                .Where(b => b.Price < 5 || b.Price>40 )
                .Select(b => new
                {
                    b.Title,
                    b.Price
                });
            foreach (var book in booksByPrice)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }
        public static void GoldenBooks(BookShopSystemContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .Select(b => new
                {
                    b.Title
                });
            foreach (var book in goldenBooks)
            {
                Console.WriteLine(book.Title);
            }
        }
        public static void BooksByAgeRestriction(BookShopSystemContext context)
        {
            Console.Write("Please write age restriction-minor or teen or adult-  ");
            string ageRestriction = Console.ReadLine();
            var books = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == ageRestriction.ToLower())
                .Select(b => new
                {
                    b.Title
                });

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }


    }
}
