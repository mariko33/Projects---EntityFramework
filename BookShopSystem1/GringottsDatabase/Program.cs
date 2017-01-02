using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GringottsDatabase.Models;

namespace GringottsDatabase
{
    class Program
    {
        static void Main()
        {
            GringottsContext context = new GringottsContext();




            //WizardDeposit deposit2=new WizardDeposit()
            //{
            //    FirstName = "Balbus",
            //    LastName = "Dumbledorv",
            //    Age = 120,
            //    MagicWandCreator = "Antioch Peverell 1",
            //    MagicWandSize = 15,
            //    DepositStartDate = new DateTime(2016, 10, 20),
            //    DepositExperationDate = new DateTime(2020, 10, 20),
            //    DepositAmount = 20000.24m,
            //    DepositCharge = 0.2,
            //    IsDepositExpired = false
            //};

            //User user1 = new User()
            //{
            //    Username = "Toshko",
            //    BirthYears = 120,
            //    Email = "bll@ggg.com",
            //    IsDeleted = false,
            //    Password = "13D@cx&d$",
            //    LastTimeLoggedIn = DateTime.Now,
            //    RegisteredOn = DateTime.Now,
            //    ProfilePicture = File.ReadAllBytes("C:\\Users\\Toshiba\\Pictures\\Nature.jpg"),
            //    FirstName="Toshko",
            //    LastName = "Todorov"
            //};

            //context.Users.Add(user1);
            //context.WizardDeposits.Add(deposit2);

            //Town plovdiv = new Town()
            //{
            //    Name = "Plovdiv",
            //    Country = "Bulgaria"
            //};
            //context.Towns.Add(plovdiv);
            // context.SaveChanges();


          //  GetUserByEmail(context, "ggg.com");

            ReceiivingTag(context);
            context.SaveChanges();
        }

        private static void GetUserByEmail(GringottsContext context, string emailProvider)
        {
            var wantedUsers = context.Users.Where(u => u.Email.EndsWith(emailProvider));
            foreach (var wantedUser in wantedUsers)
            {
                Console.WriteLine($"{wantedUser.Username} {wantedUser.Email}");
            }

        }

        private static void ReceiivingTag(GringottsContext context)
        {
            string parameterInput = Console.ReadLine();
            Tag tag=new Tag {Name = parameterInput};

            try
            {
                context.Tags.Add(tag);
                context.SaveChanges();


            }
            catch (DbEntityValidationException dbex)
            {

                tag.Name = TagTransformer.Transform(tag.Name);
                context.SaveChanges();
            }
        }
    }
}
